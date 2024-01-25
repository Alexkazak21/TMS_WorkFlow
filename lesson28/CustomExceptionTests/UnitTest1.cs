using CustomExceptionLib;

namespace CustomExceptionTests
{
    public class Tests
    { 
        [TestCase("dfkgldfg", "sffre3fsg", "sffre3fsg")]
        [TestCase("354tbgfhd", "dfdsf45gdf", "dfdsf45gdf")]
        [TestCase("FDStrgfew445", "asfdvdssfwr35y5456y", "asfdvdssfwr35y5456y")]
        public void RegForm_ValidInput_ReturnTrue(string login, string password, string confirmPassword)
        {
            var result = RegForm.CheckInputData(login, password, confirmPassword);

            Assert.That(result, Is.True, "Input credentials is valid, chech you code");
        }

        [TestCase("dfkgldf g", "sffre3fsg", "sffre3fsg")]
        [TestCase("354tbggdfgw43grgdfgdgdfgdfgfhd", "dfdsf45gdf", "dfdsf45gdf")]
        [TestCase("FDStrgfedsfdsfdsdfsdg3 dsfgs  er  w445", "asfdvdssfwr35y5456yrg", "asfdvdssfwr35y5456yrg")]
        public void RegForm_InvalidLogin_ReturnFalse(string login, string password, string confirmPassword)
        {
            var result = RegForm.CheckInputData(login, password, confirmPassword);

            Assert.That(result, Is.False, "here we have wrong Login");
        }

        [TestCase("dfkgldfg", "sffr e3fsg", "sffre3fsg")]
        [TestCase("354tbgfhd", "dfdsf45gdf", "dfd sf45gdf")]
        [TestCase("354tbgfhd", "dfdsf!_fgdfggdf", "dfdsf!_fgdfggdf")]
        [TestCase("FDStrgfew445", "asfdvdssfwr35y5456yrgdsfewfewfewfwgwgwgweefsddqw", "asfdvdasfdvdssfwr35y5456yrgdsfewfewfewfwgwgwgweefsddqwssfwr35y5456yrg")]
        public void RegForm_InvalidPassword_ReturnFalse(string login, string password, string confirmPassword)
        {
            var result = RegForm.CheckInputData(login, password, confirmPassword);

            Assert.That(result, Is.False, $"here we have wrong password");
        }
    }
}