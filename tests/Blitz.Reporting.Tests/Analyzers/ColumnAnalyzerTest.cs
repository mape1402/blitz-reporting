using Blitz.Reporting.Analyzers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Blitz.Reporting.Tests.Analyzers
{
    public sealed class ColumnAnalyzerTest
    {
        [InlineData(@"SELECT COLUMN1 AS X, COLUMN2 Y, (SELECT A FROM TABLE2 WHERE B = @PARAMETER) Z FROM TABLE", 3)]
        [Theory(DisplayName = "Validates that extract all columns from sql query.")]
        public void ExtractColumnsMetadataTest(string sql, int columnsCount)
        {
            // Arrange
            var analyzer = new ColumnAnalyzer();

            //Act
            var columns = analyzer.GetColumnsMetadata(sql).ToList();

            //Assert
            Assert.Equal(columnsCount, columns.Count());
        }
    }
}
