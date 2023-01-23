using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.Models.Extensions;

namespace TestProject1
{
    [TestClass]
    public class EnumExtensionsTests
    {
        [TestMethod]
        public void GetDescriptionTest()
        {
            //Arrange
            var status = Status.Overdue;

            //Act
            var description = status.GetDescription();

            //Assert
            Assert.AreEqual("���������", description, "��������� �������� �� ��������� � ����������� ��������� ��������");
        }

        [TestMethod]
        public void DescriptionToEnumTest()
        {
            //Arrange
            var description = "���������";

            //Act
            var status = description.ToEnum<Status>();

            //Assert
            Assert.AreEqual(Status.Overdue, status, "�������� Enum �� ��������� � ����������� ��������� Enum");
        }
    }
}