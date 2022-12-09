using FluentAssertions;
using HomesEngland.AHP.DynamicsClient.Models;
using Newtonsoft.Json;

namespace HomesEngland.AHP.UnitTests
{
    [TestClass]
    public class AssociatedEntitySerializerTests
    {

        private class TestEntity
        {
            [JsonProperty("field@odata.bind")]
            public AssociatedEntity ReferenceTable { get; set; }

            public string Name { get; set; }
        }

        [TestMethod]
        public void SerialiseAssoicatedEntity()
        {
            var result = JsonConvert.SerializeObject(new TestEntity()
            {
                Name = "testName",
                ReferenceTable = new AssociatedEntity(new Guid("12ac09d3-747c-4ac8-b920-924d56dc6c07"), "table"),
            });

            result.Should().Be("{\"field@odata.bind\":\"/table(12ac09d3-747c-4ac8-b920-924d56dc6c07)\",\"Name\":\"testName\"}");
        }
    }
}
