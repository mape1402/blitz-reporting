using Blitz.Reporting.Analyzers.Abstractions;
using Blitz.Reporting.Builder.Abstractions;
using System;
using System.Threading.Tasks;

namespace Blitz.Reporting.Builder.Internal
{
    internal sealed class ReportDesigner : IReportDesigner
    {
        private readonly ISqlAnalyzer _sqlAnalyzer;

        public ReportDesigner(ISqlAnalyzer sqlAnalyzer)
        {
            _sqlAnalyzer = sqlAnalyzer ?? throw new ArgumentNullException(nameof(sqlAnalyzer));
        }

        public async Task BeginAnalyzer(string sql)
        {
            var sqlMetadata = await _sqlAnalyzer.GetSqlMetatada(sql);
        }
    }
}
