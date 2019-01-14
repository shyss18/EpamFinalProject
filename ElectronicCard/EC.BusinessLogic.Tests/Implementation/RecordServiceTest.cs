using System;
using System.Collections.Generic;
using EC.BusinessLogic.Services.Implementation;
using EC.BusinessLogic.Services.Interfaces;
using EC.DataAccess.Repositories.Interfaces;
using EC.Entities.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EC.BusinessLogic.Tests.Implementation
{
    [TestClass]
    public class RecordServiceTest
    {
        private Mock<IRecordRepository> _recordMock;
        private Mock<IUserRepository> _userMock;
        private IRecordService _service;

        [TestInitialize]
        public void TestInitialize()
        {
            _recordMock = new Mock<IRecordRepository>();
            _userMock = new Mock<IUserRepository>();
            _service = new RecordService(_recordMock.Object, _userMock.Object);
        }

        [TestMethod]
        public void CreateRecordValid()
        {
            //Arrange
            var record = new Record
            {
                DateRecord = DateTime.Now,
                DiagnosisId = 1,
                DoctorId = 1,
                PatientId = 1,
                SickLeaveId = 1,
                Preparations = new List<Preparation>
                {
                    new Preparation
                    {
                        Id = 1,
                    }
                },
                Procedures = new List<Procedure>
                {
                    new Procedure
                    {
                        Id = 1
                    }
                }
            };

            //Act
            _service.CreateRecord(record);

            //Assert
            _recordMock.Verify(r => r.Create(record), Times.Once);
        }

        [TestMethod]
        public void CreateRecordInValid()
        {
            //Arrange
            Record record = null;

            //Act
            _service.CreateRecord(record);

            //Assert
            _recordMock.Verify(r => r.Create(record), Times.Never);
        }

        [TestMethod]
        public void UpdateRecordValid()
        {
            //Arrange
            var record = new Record
            {
                Id = 1,
                DateRecord = DateTime.Now,
                DiagnosisId = 2,
                PatientId = 3,
                DoctorId = 4,
                SickLeaveId = 2,
                Procedures = new List<Procedure>
                {
                    new Procedure
                    {
                        Id = 2
                    }
                },
                Preparations = new List<Preparation>
                {
                    new Preparation
                    {
                        Id = 3
                    }
                }
            };

            //Act
            _service.UpdateRecord(record);

            //Assert
            _recordMock.Verify(r => r.Update(record), Times.Once);
        }

        [TestMethod]
        public void UpdateRecordInvalid()
        {
            //Arrange
            Record record = null;

            //Act
            _service.UpdateRecord(record);

            //Assert
            _recordMock.Verify(r => r.Update(record), Times.Never);
        }

        [TestMethod]
        public void DeleteRecordValid()
        {
            //Arrange
            int? id = 1;

            //Act
            _service.DeleteRecord(id);

            //Assert
            _recordMock.Verify(r => r.Delete(id), Times.Once);
        }

        [TestMethod]
        public void DeleteRecordInvalid()
        {
            //Arrange
            int? id = null;

            //Act
            _service.DeleteRecord(id);

            //Assert
            _recordMock.Verify(r => r.Delete(id), Times.Never);
        }

        [TestMethod]
        public void GetRecordByIdValid()
        {
            //Arrange
            int? id = 1;

            _recordMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((int idTest) => new Record
            {
                Id = idTest
            });

            //Act
            var result = _service.GetRecordById(id);

            //Assert
            Assert.AreEqual(id, result.Id);
        }

        [TestMethod]
        public void GetRecordByIdInvalid()
        {
            //Arrange
            int? id = 0;

            //Act
            var result = _service.GetRecordById(id);

            //Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetPatientRecordsValid()
        {
            //Arrange
            string login = "login";

            _recordMock.Setup(r => r.GetPatientRecords(It.IsAny<int>())).Returns((int id) => new List<Record>
            {
                new Record
                {
                    Id = id
                }
            });

            _userMock.Setup(r => r.GetUserByLogin(It.IsAny<string>())).Returns((string loginTest) => new User
            {
                Login = loginTest
            });

            //Act
            var result = _service.GetPatientRecords(login);

            //Assert
            _userMock.Verify(u => u.GetUserByLogin(login), Times.Once);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetPatientRecordsInValid()
        {
            //Arrange
            string login = null;

            _recordMock.Setup(r => r.GetPatientRecords(It.IsAny<int>())).Returns((int id) => new List<Record>
            {
                new Record
                {
                    Id = id
                }
            });

            //Act
            var result = _service.GetPatientRecords(login);

            //Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetDoctorRecordsValid()
        {
            //Arrange
            string login = "login";

            _recordMock.Setup(r => r.GetDoctorRecords(It.IsAny<int>())).Returns((int id) => new List<Record>
            {
                new Record
                {
                    Id = id
                }
            });

            _userMock.Setup(r => r.GetUserByLogin(It.IsAny<string>())).Returns((string loginTest) => new User
            {
                Login = loginTest
            });

            //Act
            var result = _service.GetDoctorRecords(login);

            //Assert
            _userMock.Verify(u => u.GetUserByLogin(login), Times.Once);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDoctorRecordsInValid()
        {
            //Arrange
            string login = null;

            _recordMock.Setup(r => r.GetDoctorRecords(It.IsAny<int>())).Returns((int id) => new List<Record>
            {
                new Record
                {
                    Id = id
                }
            });

            //Act
            var result = _service.GetDoctorRecords(login);

            //Assert
            Assert.AreEqual(null, result);
        }

    }
}
