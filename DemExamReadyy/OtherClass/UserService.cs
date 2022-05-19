using DemExamReadyy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemExamReadyy.OtherClass
{
    public class UserService
    {

        private static UserService instance;

        private UserService()
        {

        }
        public static UserService Instance => instance == null ? instance = new UserService() : instance;
        public BaseEmployes baseEmployes { get; set; }
    }
}
