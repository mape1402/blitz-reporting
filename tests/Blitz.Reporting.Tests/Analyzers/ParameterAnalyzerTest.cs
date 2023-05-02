using System.Linq;

using Xunit;

using Blitz.Reporting.Analyzers;
using Blitz.Reporting.Analyzers.Exceptions;

namespace Blitz.Reporting.Tests.Analyzers
{
    public sealed class ParameterAnalyzerTest 
    {
        [InlineData("SELECT * FROM TABLE WHERE COLUMN = @Parameter", 1)]
        [InlineData("SELECT * FROM TABLE WHERE COLUMN = @Parameter AND COLUMN = @Parameter2", 2)]
        [InlineData("SELECT * FROM TABLE WHERE COLUMN = @Parameter AND COLUMN IN (@Par1,@Par2,@Par3, @Par4)", 5)]
        [InlineData("SELECT COLUMN, @PARAMETER1 FROM TABLE WHERE COLUMN = @Parameter AND COLUMN2 = @PARAMETER1", 2)]
        [InlineData("SELECT *, @PARAMETER4 FROM TABLE WHERE COLUMN = (SELECT COUNT(*) FROM TABLE2 WHERE X = @PARAMETER1) AND COLUMN2=@PARAMETER2 AND Y = @PARAMETER3", 4)]
        [InlineData("SELECT * FROM TABLE", 0)]
        [InlineData(@"SELECT * 
                        FROM TABLE
                        WHERE X = @PARAMETER
                        ORDER BY X", 1)]
        [Theory(DisplayName = "Validates that extract all parameters from sql query.")]
        public void ExtractParametersMetadataTest(string sql, int parametersCount)
        {
            //Arrange 
            var parameterAnalyzer = new ParameterAnalyzer();

            //Act
            var parameters = parameterAnalyzer.ExtractParametersMetadata(sql);

            //Assert
            Assert.Equal(parametersCount, parameters.Count());
        }

        [InlineData("SELECT * FROM TABLE WHERE COLUMN = @Parameter", false)]
        [InlineData("SELECT * FROM TABLE WHERE COLUMN = @", true)]
        [Theory(DisplayName = "Validates that extracted parameters are valid or not.")]
        public void ExtractParametersMetadataTest_Validate(string sql, bool expectedException)
        {
            //Arrange
            var parameterAnalyzer = new ParameterAnalyzer();

            var throwedException = false;

            try
            {
                //Act
                var parameters = parameterAnalyzer.ExtractParametersMetadata(sql);
                parameters.ToList(); // Invoke lazy load!

            }
            catch (InvalidParameterException)
            {
                throwedException = true;
            }

            //Assert
            Assert.Equal(expectedException, throwedException);
        }
    }
}
