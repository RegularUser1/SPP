using FakerLab;
using FakerLab.Fakers;

var config = new FakerConfig();
config.Add<MyDto, string, CustomStringGenerator>(dto => dto.String!);

var faker = new Faker(config);

faker.AddGeneratorWithPlugin("Plugins/DateTimeGeneratorPlugin.dll");
faker.AddGeneratorWithPlugin("Plugins/ListGeneratorPlugin.dll");

Console.WriteLine(faker.Create<MyDto>());