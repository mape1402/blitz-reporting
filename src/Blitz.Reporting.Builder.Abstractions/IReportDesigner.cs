using System.Threading.Tasks;

namespace Blitz.Reporting.Builder.Abstractions
{
    public interface IReportDesigner
    {
        Task BeginAnalyzer(string sql);
    }
}
