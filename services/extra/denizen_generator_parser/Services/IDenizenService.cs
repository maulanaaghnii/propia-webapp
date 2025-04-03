using System.Threading.Tasks;
using denizen_generator_parser.Models;
using System.Collections.Generic;

namespace denizen_generator_parser.Services
{
    public interface IDenizenService
    {
        Task<(IEnumerable<object> Data, int TotalLost, int Attempts, bool IsServiceDown)> GeneratePersonsData(GenerateRequest request);
        Task<IEnumerable<DenizenGeneratorMonitoring>> GetMonitoringData();
        Task SaveMonitoringData(DenizenGeneratorMonitoring monitoring);
    }
}
