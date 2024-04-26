namespace AssemblyExample.AnotherNamespace
{
    internal class DataProcessor
    {
        protected bool isProcessing { get; set; }

        public async Task Process<T>(T data, int aspect)
        {
            isProcessing = true;
        }

        public virtual void StopProcessing()
        {
            isProcessing = false;
        }
    }
}
