using System.Configuration;

namespace EC.Common.Helpers
{
    public static class DbConstants
    {
        #region Diagnosis

        public const string CREATE_DIAGNOSIS = "CreateDiagnosis";
        public const string DELETE_DIAGNOSIS = "DeleteDiagnosis";
        public const string UPDATE_DIAGNOSIS = "UpdateDiagnosis";
        public const string GET_BY_ID_DIAGNOSIS = "GetDiagById";
        public const string GET_ALL_DIAGNOSIS = "GetAllDiag";

        #endregion

        #region Phone

        public const string CREATE_PHONE = "CreatePhone";
        public const string DELETE_PHONE = "DeletePhone";
        public const string UPDATE_PHONE = "UpdatePhone";
        public const string GET_USER_PHONE = "GetUserPhone";

        #endregion

        #region Preparation

        public const string CREATE_PREPARATION = "CreatePreparation";
        public const string DELETE_PREPARATION = "DeletePreparation";
        public const string GET_ALL_PREPARATION = "GetAllPreparations";
        public const string GET_PREPARATION_BY_ID = "GetPreparationById";
        public const string UPDATE_PREPARATION = "UpdatePreparation";

        #endregion

        #region Procedure

        public const string CREATE_PROCEDURE = "CreateProcedure";
        public const string DELETE_PROCEDURE = "DeleteProcedure";
        public const string GET_ALL_PROCEDURES = "GetAllProcedures";
        public const string GET_PROCEDURE_BY_ID = "GetProcedureById";
        public const string UPDATE_PROCEDURE = "UpdateProcedure";

        #endregion

        #region Record

        public const string CREATE_RECORD = "CreateRecord";
        public const string DELETE_RECORD = "DeleteRecords";
        public const string UPDATE_RECORD = "UpdateRecord";
        public const string GET_USER_RECORDS = "GetUserRecords";

        #endregion

        #region Role

        public const string CREATE_ROLE = "CreateRole";
        public const string DELETE_ROLE = "DeleteRole";
        public const string UPDATE_ROLE = "UpdateRole";
        public const string GET_ALL_ROLES = "GetAllRole";
        public const string GET_ROLE_BY_ID = "GetRoleById";

        #endregion

        #region SickLeave

        public const string CREATE_SICKLEAVE = "CreateSickLeave";
        public const string DELETE_SICKLEAVE = "DeleteSickLeave";
        public const string GET_ALL_SICKLEAVES = "GetAllSickLeaves";
        public const string GET_SICKLEAVE_BY_ID = "GetSickLeaveById";
        public const string UPDATE_SICKLEAVE = "UpdateSickLeave";

        #endregion

        #region User

        public const string CREATE_USER = "CreateUser";
        public const string DELETE_USER = "DeleteUser";
        public const string GET_ALL_DOCTORS = "GetAllDoctors";
        public const string GET_ALL_PATIENTS = "GetAllPatients";
        public const string GET_ALL_USERS = "GetAllUsers";
        public const string GET_USER_BY_ID = "GetUserById";
        public const string UPDATE_USER = "UpdateUser";

        #endregion

        #region ConnectionString

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionElectronicCardDB"].ConnectionString;

        #endregion
    }
}
