using System;
using System.Data;
using DVLD_DataAccessLayer;
namespace DVLD_BussinessLayer
{
    public class clsRetakeTest
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int RetakeTestID { get; set; }
        public int TestAppointment_id { get; set; }
        public decimal RetakeTestFees { get; set; }

        public clsRetakeTest()
        {
            this.RetakeTestID = default;
            this.TestAppointment_id = default;
            this.RetakeTestFees = default;


            Mode = enMode.AddNew;

        }

        private clsRetakeTest(int RetakeTestID, int TestAppointment_id, decimal RetakeTestFees)
        {
            this.RetakeTestID = RetakeTestID;
            this.TestAppointment_id = TestAppointment_id;
            this.RetakeTestFees = RetakeTestFees;


            Mode = enMode.Update;

        }

        private bool _AddNewRetakeTest()
        {
            //call DataAccess Layer 

            this.RetakeTestID = clsRetakeTestsDataAccess.AddNewRetakeTest(this.TestAppointment_id, this.RetakeTestFees);

            return (this.RetakeTestID != -1);

        }

        private bool _UpdateRetakeTest()
        {
            //call DataAccess Layer 

            return clsRetakeTestsDataAccess.UpdateRetakeTest(this.RetakeTestID, this.TestAppointment_id, this.RetakeTestFees);

        }

        public static clsRetakeTest Find(int RetakeTestID)
        {
            int TestAppointment_id = default;
            decimal RetakeTestFees = default;


            if (clsRetakeTestsDataAccess.GetRetakeTestInfoByID(RetakeTestID, ref TestAppointment_id, ref RetakeTestFees))
                return new clsRetakeTest(RetakeTestID, TestAppointment_id, RetakeTestFees);
            else
                return null;

        }

        public static clsRetakeTest FindRtestInfoByTestAppointmentID(int TestAppointmentID)
        {
            int RetakeTestID = default;
            decimal RetakeTestFees = default;


            if (clsRetakeTestsDataAccess.GetRetakeTestInfoByTestAppointmentID(ref RetakeTestID, TestAppointmentID, ref RetakeTestFees))
                return new clsRetakeTest(RetakeTestID, TestAppointmentID, RetakeTestFees);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRetakeTest())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateRetakeTest();

            }

            return false;
        }

        public static DataTable GetAllRetakeTests() { return clsRetakeTestsDataAccess.GetAllRetakeTests(); }

        public static bool DeleteRetakeTest(int RetakeTestID) { return clsRetakeTestsDataAccess.DeleteRetakeTest(RetakeTestID); }

        public static bool isRetakeTestExist(int RetakeTestID) { return clsRetakeTestsDataAccess.IsRetakeTestExist(RetakeTestID); }


    }

}