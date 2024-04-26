using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks.Dataflow;

namespace TestsGeneratorLib
{
    public static class TestGenerator
    {
        public static Task Generate(string[] files, string outputFolder, int maxThreads)
        {
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            var options = new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = maxThreads };
            var readFileBlock = new TransformBlock<string, string>(
                async filePath => await File.ReadAllTextAsync(filePath),
                options
            );
            var getCompilationUnitBlock = new TransformBlock<string, List<(string OutputPath, CompilationUnitSyntax Unit)>>(
                fileContent => ParseTestFile(fileContent, outputFolder).ToList(),
                options
            );
            var writeToFileBlock = new ActionBlock<List<(string OutputPath, CompilationUnitSyntax Unit)>>(
                async result =>
                {
                    await Parallel.ForEachAsync(
                        result,
                        new ParallelOptions { MaxDegreeOfParallelism = maxThreads },
                        async (r, cancel) =>
                        {
                            await File.WriteAllTextAsync(r.OutputPath, r.Unit.NormalizeWhitespace().ToFullString(), cancel);
                            Console.WriteLine(r.Unit.NormalizeWhitespace().ToFullString());
                        }
                    );
                },
                options
            );

            var dataflowLinkOptions = new DataflowLinkOptions { PropagateCompletion = true };
            readFileBlock.LinkTo(getCompilationUnitBlock, dataflowLinkOptions);
            getCompilationUnitBlock.LinkTo(writeToFileBlock, dataflowLinkOptions);

            foreach (string file in files)
            {
                readFileBlock.SendAsync(file);
            }

            readFileBlock.Complete();
            return writeToFileBlock.Completion;
        }

        public static IEnumerable<(string OutputPath, CompilationUnitSyntax Unit)> ParseTestFile(
            string fileContent,
            string outputFolder
        )
        {
            throw new NotImplementedException();
        }
    }
}