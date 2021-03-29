using System;
using System.Text.Json;
using SW.Mosaic.ColorCalculation;
using SW.Mosaic.ColorCalculation.Model;
namespace SW.Mosaic.ColorToolLabConverter
{
    public class CoordinateMapper
    {
        private CIELab MapRawToCieLab(string rawData, string illuminantObserver)
        {
            var spectrumToXyzConverter = new SpectrumToXYZConverter();
            var xyzToLabConverter = new ColorSpaceHelper(spectrumToXyzConverter);
            var spectrumToLabConverter = new SpectrumToLabConverter(spectrumToXyzConverter, xyzToLabConverter);
            var coordinateMapper = new ColorCalculation.CoordinateMapper(spectrumToLabConverter);

            return coordinateMapper.MapRawToCieLab(rawData, illuminantObserver);
        }

        public string ConvertCIELabToJson(string rawData, string illuminantObserver)
        {
            Console.WriteLine("Calling 'MapRawToCieLab' to retrieve the LAB conversion as a CieLab object\n");

            var result = MapRawToCieLab(rawData, illuminantObserver);

            Console.WriteLine("Serializing the Object to JSON\n\n");

            return JsonSerializer.Serialize(result);
        }

    }
}
