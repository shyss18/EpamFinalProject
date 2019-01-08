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
        public const string GET_USER_PHONES = "GetUserPhone";
        public const string GET_PHONE_BY_ID = "GetPhoneById";

        #endregion

        #region Preparation

        public const string CREATE_PREPARATION = "CreatePreparation";
        public const string DELETE_PREPARATION = "DeletePreparation";
        public const string GET_ALL_PREPARATION = "GetAllPreparations";
        public const string GET_PREPARATION_BY_ID = "GetPreparationById";
        public const string UPDATE_PREPARATION = "UpdatePreparation";
        public const string ADD_PREPARATION_TO_RECORD = "AddPrepartionToRecord";
        public const string GET_PREPARATIONS_BY_RECORD = "GetPreparationsByRecord";

        #endregion

        #region Procedure

        public const string CREATE_PROCEDURE = "CreateProcedure";
        public const string DELETE_PROCEDURE = "DeleteProcedure";
        public const string GET_ALL_PROCEDURES = "GetAllProcedures";
        public const string GET_PROCEDURE_BY_ID = "GetProcedureById";
        public const string UPDATE_PROCEDURE = "UpdateProcedure";
        public const string ADD_PROCEDURE_TO_RECORD = "AddProcedureToRecord";
        public const string GET_PROCEDURES_BY_RECORD = "GetProceduresByRecord";

        #endregion

        #region Record

        public const string CREATE_RECORD = "CreateRecord";
        public const string DELETE_RECORD = "DeleteRecords";
        public const string UPDATE_RECORD = "UpdateRecord";
        public const string GET_PATIENT_RECORDS = "GetPatientRecords";
        public const string GET_DOCTOR_RECORDS = "GetDoctorRecords";
        public const string GET_ALL_RECORDS = "GetAllRecords";
        public const string GET_RECORD_BY_ID = "GetRecordById";
        public const string DELETE_RECORD_PREPARATIONS = "DeleteRecordPreparations";
        public const string DELETE_RECORD_PROCEDURES = "DeleteRecordProcedures";
        
        #endregion

        #region Role

        public const string CREATE_ROLE = "CreateRole";
        public const string DELETE_ROLE = "DeleteRole";
        public const string UPDATE_ROLE = "UpdateRole";
        public const string GET_ALL_ROLES = "GetAllRole";
        public const string GET_ROLE_BY_ID = "GetRoleById";
        public const string ADD_ROLE_TO_USER = "AddRoleToUser";
        public const string DELETE_USER_ROLES = "DeleteUserRoles";
        public const string GET_USER_ROLES = "GetUserRoles";

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
        public const string GET_USER_BY_LOGIN = "GetUserByLogin";
        public const string ADD_PATIENT_TO_DOCTOR = "AddPatientToDoctor";
        public const string GET_USER_DOCTORS = "GetUserDoctors";
        public const string GET_USER_PATIENTS = "GetUserPatients";
        public const string DELETE_USER_PATIENTS = "DeleteUserPatients";
        public const string DELETE_USER_DOCTORS = "DeleteUserDoctors";

        #endregion

        #region Photo

        public const string CREATE_PHOTO = "CreatePhoto";
        public const string UPDATE_PHOTO = "UpdatePhoto";
        public const string DELETE_PHOTO = "DeletePhoto";
        public const string GET_PHOTO_BY_ID = "GetPhotoById";
        public const string GET_USER_PHOTO = "GetUserPhoto";

        #endregion

        #region ConnectionString

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionElectronicCardDB"].ConnectionString;

        #endregion
    }
}
