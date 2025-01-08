using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.ComManager;
using VP_QM_winform.VO;

namespace VP_QM_winform.DAO
{
    public class EmployeeDAO
    {
        private SQLManager sqlManager = new SQLManager();
        public EmployeeVO getEmployee(int employeeNumber)
        {
            var connection = sqlManager.GetConnection();
            var query = "SELECT * FROM employee WHERE CONCAT(year, gender, LPAD(sequence::TEXT, 4, '0')) = @EmployeeNumber::TEXT;";
            try
            {
                var result = connection.QuerySingleOrDefault<EmployeeVO>(query, new { EmployeeNumber = employeeNumber });
                return result;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
