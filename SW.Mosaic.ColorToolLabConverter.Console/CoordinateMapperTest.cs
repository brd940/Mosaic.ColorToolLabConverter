using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using SW.Mosaic.ColorCalculation.Model;

namespace SW.Mosaic.ColorToolLabConverter.Console
{
    class CoordinateMapperTest
    {
        static void Main(string[] args)
        {
            var calculator = new CoordinateMapper();

            var rawData = args[0];

            var illuminantObserver = args[1];

            System.Console.WriteLine($"Calling 'ConvertCieLabToJson' in 'CoordinateMapper.DLL'\n");
            System.Console.WriteLine($"With Arguments:\nRaw Data: {rawData}\nIlluminant Observer: {illuminantObserver}\n\n");

            var result = calculator.ConvertCIELabToJson(rawData, illuminantObserver);
            
            System.Console.WriteLine($"Result as JSON:\n{result}");
        }
    }
}
