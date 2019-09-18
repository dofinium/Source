using PralnaDemo.Models;
using PralnaDemo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PralnaDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Seed();
        }

        private void Seed()
        {


            PralnaEntities db = new PralnaEntities();
            if (db.Cities.Any())
            {
                return;
            }

            #region City

            City someCity = new City { Name = "Одеса" };
            db.Cities.Add(someCity);
            db.SaveChanges();

            someCity = new City { Name = "Київ" };
            db.Cities.Add(someCity);
            db.SaveChanges();
            #endregion

            #region Organizations 5
            Organization someOrganization = new Organization { Name = "Податкова інспекція Суворовського района", CityId = 1, Description = "вул. ак. Заболотного 38" };
            db.Organizations.Add(someOrganization); //1
            db.SaveChanges();

            //2
            someOrganization = new Organization { Name = "Податкова інспекція Київського района", CityId = 1, Description = "вул. ак. Корольова 38" };
            db.Organizations.Add(someOrganization);
            db.SaveChanges();

            //3
            someOrganization = new Organization { Name = "Податкова інспекція Деснянського района", CityId = 2, Description = "вул.  Печерська 38" };
            db.Organizations.Add(someOrganization);
            db.SaveChanges();

            //4
            someOrganization = new Organization { Name = "Податкова інспекція Соломенського района", CityId = 2, Description = "вул.  Губарева 38" };
            db.Organizations.Add(someOrganization);
            db.SaveChanges();

            //5
            someOrganization = new Organization { Name = "Адміністрація Приморського району", CityId = 1, Description = "вул.  Пушкіна 38" };
            db.Organizations.Add(someOrganization);
            db.SaveChanges();

            //6
            someOrganization = new Organization { Name = "ЖКС-37", CityId = 1, Description = "вул.  Тупольова 38" };
            db.Organizations.Add(someOrganization);
            db.SaveChanges();

            #endregion

            #region Divisions 16
            Division someDivision = new Division { Name = "Апарат", OrganizationId = 1 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();

            someDivision = new Division { Name = "Апарат", OrganizationId = 2 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();


            someDivision = new Division { Name = "Апарат", OrganizationId = 3 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();

            someDivision = new Division { Name = "Апарат", OrganizationId = 4 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();

            someDivision = new Division { Name = "Прийомна", OrganizationId = 1 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();

            someDivision = new Division { Name = "Прийомна", OrganizationId = 2 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();


            someDivision = new Division { Name = "Прийомна", OrganizationId = 3 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();

            someDivision = new Division { Name = "Прийомна", OrganizationId = 4 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();


            someDivision = new Division { Name = "Юридичний відділ", OrganizationId = 1 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();

            someDivision = new Division { Name = "Юридичний відділ", OrganizationId = 2 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();


            someDivision = new Division { Name = "Юридичний відділ", OrganizationId = 3 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();

            someDivision = new Division { Name = "Юридичний відділ", OrganizationId = 4 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();

            someDivision = new Division { Name = "Земельний відділ", OrganizationId = 5 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();

            someDivision = new Division { Name = "Ремонтніки", OrganizationId = 6 };
            db.Divisions.Add(someDivision);
            db.SaveChanges();


            #endregion

            #region Work places

            WorkPlace someWorkPlace = new WorkPlace { Name = "Начальник", DivisionId = 1 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Начальник", DivisionId = 2 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Начальник", DivisionId = 3 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Начальник", DivisionId = 4 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Инспектор ревизионного отдела", DivisionId = 5 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Инспектор ревизионного отдела", DivisionId = 6 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Инспектор ревизионного отдела", DivisionId = 7 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Инспектор ревизионного отдела", DivisionId = 8 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Головний инспектор", DivisionId = 9 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Старший инспектор", DivisionId = 10 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Головний инспектор", DivisionId = 11 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Старший инспектор", DivisionId = 12 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Прибіральник", DivisionId = 13 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Спеціаліст", DivisionId = 14 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Сантехник", DivisionId = 14 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Електрик", DivisionId = 14};
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();

            someWorkPlace = new WorkPlace { Name = "Водій", DivisionId = 14 };
            db.WorkPlaces.Add(someWorkPlace);
            db.SaveChanges();







            #endregion

            #region Workers
            RandomOperations randomOp = new RandomOperations();
            AspNetUser someUser = new AspNetUser { Id = "e2d6ea9d-47ad-4604-99f8-ee989ae23f3c", UserName = "admin@email.no", Email = "admin@email.no", Name = "Адміністратор", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10)};
            db.AspNetUsers.Add(someUser);

            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                string mess = ex.Message;
            }

            Guid someGuid = Guid.NewGuid();

            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker1@email.no", Email = "worker1@email.no", Name = "Загорулько В.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0 , Photo="/images/worker1.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10)};
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();

            Worker someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 1 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker2@email.no", Email = "worker2@email.no", Name = "Заречна Т.П.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker2.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 2 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker3@email.no", Email = "worker3@email.no", Name = "Антоненко Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker3.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 3 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker4@email.no", Email = "worker4@email.no", Name = "Бондар Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker4.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 4 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker5@email.no", Email = "worker5@email.no", Name = "П'ятихаткин Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker5.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 5 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker6@email.no", Email = "worker6@email.no", Name = "Шестакова Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker6.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 6 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker7@email.no", Email = "worker7@email.no", Name = "Семеренко Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker7.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 7 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker8@email.no", Email = "worker8@email.no", Name = "Восьмушкіна Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker8.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 8 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker9@email.no", Email = "worker9@email.no", Name = "Дев'яткіна Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker9.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 9 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker10@email.no", Email = "worker10@email.no", Name = "Десятенко Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker10.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 10 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker11@email.no", Email = "worker11@email.no", Name = "Ладиненко Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker11.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 11 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker12@email.no", Email = "worker12@email.no", Name = "Дваначан Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker12.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 12 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker13@email.no", Email = "worker13@email.no", Name = "Триколорина Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker13.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 13 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker14@email.no", Email = "worker14@email.no", Name = "Четвертенко Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker14.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 14 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker15@email.no", Email = "worker15@email.no", Name = "П'ятнашкіна Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker15.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 15 };
            db.Workers.Add(someWorker);
            db.SaveChanges();


            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "worker16@email.no", Email = "worker16@email.no", Name = "Доброділ Б.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, Photo = "/images/worker16.jpg", TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();
            someWorker = new Worker { AspNetUserId = someUser.Id, IsFormer = false, StartDate = DateTime.Now, WorkPlaceId = 16 };
            db.Workers.Add(someWorker);
            db.SaveChanges();

            #endregion

            #region Violations
            ViolationType someViolationType = new ViolationType { Name = "Затягування часу", Description = "Виникає якщо робітник не впорався з завданням у встановлений ліміт часу", OrganizationId = 1 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Зайві питання", Description = "Якщо робітник запросив документ, відсутній у переліку необхідних", OrganizationId = 1 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Некомпетентність", Description = "Якщо робітник не знає, як відповисти", OrganizationId = 1 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Приховування інформації", Description = "Виявлені порушення у зв'язку з неповною консультацією", OrganizationId = 1 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();


            someViolationType = new ViolationType { Name = "Затягування часу", Description = "Виникає якщо робітник не впорався з завданням у встановлений ліміт часу", OrganizationId = 2 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Зайві питання", Description = "Якщо робітник запросив документ, відсутній у переліку необхідних", OrganizationId = 2 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Некомпетентність", Description = "Якщо робітник не знає, як відповисти", OrganizationId = 2 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Приховування інформації", Description = "Виявлені порушення у зв'язку з неповною консультацією", OrganizationId = 2 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();


            someViolationType = new ViolationType { Name = "Затягування часу", Description = "Виникає якщо робітник не впорався з завданням у встановлений ліміт часу", OrganizationId = 3 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Зайві питання", Description = "Якщо робітник запросив документ, відсутній у переліку необхідних", OrganizationId = 3 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Некомпетентність", Description = "Якщо робітник не знає, як відповисти", OrganizationId = 3 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Приховування інформації", Description = "Виявлені порушення у зв'язку з неповною консультацією", OrganizationId = 3 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();


            someViolationType = new ViolationType { Name = "Затягування часу", Description = "Виникає якщо робітник не впорався з завданням у встановлений ліміт часу", OrganizationId = 4 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Зайві питання", Description = "Якщо робітник запросив документ, відсутній у переліку необхідних", OrganizationId = 4 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Некомпетентність", Description = "Якщо робітник не знає, як відповисти", OrganizationId = 4 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Приховування інформації", Description = "Виявлені порушення у зв'язку з неповною консультацією", OrganizationId = 4 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            // Адміністрація Приморського району
            someViolationType = new ViolationType { Name = "Затягування часу", Description = "Виникає якщо робітник не впорався з завданням у встановлений ліміт часу", OrganizationId = 5 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Зайві питання", Description = "Якщо робітник запросив документ, відсутній у переліку необхідних", OrganizationId = 5 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Некомпетентність", Description = "Якщо робітник не знає, як відповисти", OrganizationId = 5 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Приховування інформації", Description = "Виявлені порушення у зв'язку з неповною консультацією", OrganizationId = 5 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Відсутній на місці", Description = "Відповідальної особи немає на роботі", OrganizationId = 5 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            // ЖКС
            someViolationType = new ViolationType { Name = "Виявилися недоробки", Description = "", OrganizationId = 6 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Залишив бруд", Description = "Якщо робітник запросив документ, відсутній у переліку необхідних", OrganizationId = 6 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();

            someViolationType = new ViolationType { Name = "Некомпетентність", Description = "Якщо робітник не знає, як зробити справу", OrganizationId = 6 };
            db.ViolationTypes.Add(someViolationType);
            db.SaveChanges();


            #endregion

            #region Картки послуг

            ServiceType someServiceType = new ServiceType { Name = "Здача звіту 1-ДФ", Description = "1. Прибути до віконця 18;\r\n2. Залишити звіт інспектору;\r\n3. Покинути інспекцію.", TimeLimit = new TimeSpan(0, 0, 3, 0, 0), UseTimeLimit = true, WorkPlaceId = 1 };
            db.ServiceTypes.Add(someServiceType);
            db.SaveChanges();

            AllowedViolation someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 1 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 2 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someServiceType = new ServiceType { Name = "Консультація", Description = "1. Прибути до кабинету 28;\r\n2. Отримати вичерпну консультацію та письмове роз'яснення;\r\n3. Покинути інспекцію.", TimeLimit = new TimeSpan(0, 0, 30, 0, 0), UseTimeLimit = true, WorkPlaceId = 1 };
            db.ServiceTypes.Add(someServiceType);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 3 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 4 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();


            someServiceType = new ServiceType { Name = "Здача звіту 8-ДР", Description = "1. Прибути до віконця 18;\r\n2. Залишити звіт інспектору;\r\n3. Покинути інспекцію.", TimeLimit = new TimeSpan(0, 0, 6, 0, 0), UseTimeLimit = true, WorkPlaceId = 1 };
            db.ServiceTypes.Add(someServiceType);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 1 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 2 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();


            someServiceType = new ServiceType { Name = "Здача звіту 1-ДФ", Description = "1. Прибути до віконця 18;\r\n2. Залишити звіт інспектору;\r\n3. Покинути інспекцію.", TimeLimit = new TimeSpan(0, 0, 3, 0, 0), UseTimeLimit = true, WorkPlaceId = 2 };
            db.ServiceTypes.Add(someServiceType);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 1 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 2 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someServiceType = new ServiceType { Name = "Консультація", Description = "1. Прибути до кабинету 28;\r\n2. Отримати вичерпну консультацію та письмове роз'яснення;\r\n3. Покинути інспекцію.", TimeLimit = new TimeSpan(0, 0, 30, 0, 0), UseTimeLimit = true, WorkPlaceId = 2 };
            db.ServiceTypes.Add(someServiceType);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 3 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 4 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();


            someServiceType = new ServiceType { Name = "Здача звіту 8-ДР", Description = "1. Прибути до віконця 18;\r\n2. Залишити звіт інспектору;\r\n3. Покинути інспекцію.", TimeLimit = new TimeSpan(0, 0, 6, 0, 0), UseTimeLimit = true, WorkPlaceId = 2 };
            db.ServiceTypes.Add(someServiceType);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 1 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 2 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someServiceType = new ServiceType { Name = "Здача звіту 1-ДФ", Description = "1. Прибути до віконця 18;\r\n2. Залишити звіт інспектору;\r\n3. Покинути інспекцію.", TimeLimit = new TimeSpan(0, 0, 3, 0, 0), UseTimeLimit = true, WorkPlaceId = 3 };
            db.ServiceTypes.Add(someServiceType);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 1 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 2 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someServiceType = new ServiceType { Name = "Консультація", Description = "1. Прибути до кабинету 28;\r\n2. Отримати вичерпну консультацію та письмове роз'яснення;\r\n3. Покинути інспекцію.", TimeLimit = new TimeSpan(0, 0, 30, 0, 0), UseTimeLimit = true, WorkPlaceId = 3 };
            db.ServiceTypes.Add(someServiceType);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 3 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 4 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();


            someServiceType = new ServiceType { Name = "Здача звіту 8-ДР", Description = "1. Прибути до віконця 18;\r\n2. Залишити звіт інспектору;\r\n3. Покинути інспекцію.", TimeLimit = new TimeSpan(0, 0, 6, 0, 0), UseTimeLimit = true, WorkPlaceId = 3 };
            db.ServiceTypes.Add(someServiceType);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 1 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            someAllowedViolation = new AllowedViolation { ServiceTypeId = someServiceType.Id, ViolationTypeId = 2 };
            db.AllowedViolations.Add(someAllowedViolation);
            db.SaveChanges();

            #endregion

            #region Clients

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "client1@email.no", Email = "client1@email.no", Name = "Щасливий В.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "client2@email.no", Email = "client2@email.no", Name = "Вторенко В.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "client3@email.no", Email = "client3@email.no", Name = "Третяк В.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();


            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "client4@email.no", Email = "client4@email.no", Name = "Четверенко В.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "client5@email.no", Email = "client5@email.no", Name = "П'ятаков В.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "client6@email.no", Email = "client6@email.no", Name = "Шустер В.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "client7@email.no", Email = "client7@email.no", Name = "Сьомкін В.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "client8@email.no", Email = "client8@email.no", Name = "Васюленко В.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();

            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "client9@email.no", Email = "client9@email.no", Name = "Дубенко В.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();


            someGuid = Guid.NewGuid();
            someUser = new AspNetUser { Id = someGuid.ToString(), UserName = "client10@email.no", Email = "client10@email.no", Name = "Пупенко В.", PasswordHash = "AJ6/t/lzNUePfTI9JEvW5bB1DiylzX02uggwU/ioqDRwxMHCyHLLY8Umxs2oSyXLPg==", SecurityStamp = "7f08faa0-561b-4572-9783-a146898255c2", AccessFailedCount = 0, TaxNumber = randomOp.GetSubstring(randomOp.getConfirmationCode(), 10) };
            db.AspNetUsers.Add(someUser);
            db.SaveChanges();




            #endregion

            GenerateServices();

        }


        public void GenerateServices()
        {
            RandomOperations randomOp = new RandomOperations();
            PralnaEntities db = new PralnaEntities();

            #region Заявки на услуги и полученные услуги
            // успешно
            ServiceToClient someServiceToClient = new ServiceToClient { ServiceTypeId = 1, UniqueKey = randomOp.GetSubstring(randomOp.getConfirmationCode(), 6), Assigned = DateTime.Now, Started = DateTime.Now, Finished = DateTime.Now.AddMinutes(1), IsCallbackAllowed = true, ValueSet = DateTime.Now.AddSeconds(20), WorkerId = 1, Value = 1, ClientId = GetRandomClient().Id };
            db.ServiceToClients.Add(someServiceToClient);
            db.SaveChanges();

            someServiceToClient = new ServiceToClient { ServiceTypeId = 2, UniqueKey = randomOp.GetSubstring(randomOp.getConfirmationCode(), 6), Assigned = DateTime.Now, Started = DateTime.Now, Finished = DateTime.Now.AddMinutes(1), IsCallbackAllowed = true, ValueSet = DateTime.Now.AddSeconds(20), WorkerId = 2, Value = -1, ClientId = GetRandomClient().Id };
            db.ServiceToClients.Add(someServiceToClient);
            db.SaveChanges();

            FoundViolation someViolationFound = new FoundViolation { ServiceToClientId = someServiceToClient.Id, ViolationTypeId = 1 };
            db.FoundViolations.Add(someViolationFound);
            db.SaveChanges();
            someServiceToClient.ClientFeedback = "Работник хрумкал семки во время приёма";
            db.Entry(someServiceToClient).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            someServiceToClient = new ServiceToClient { ServiceTypeId = 1, UniqueKey = randomOp.GetSubstring(randomOp.getConfirmationCode(), 6), Assigned = DateTime.Now.AddDays(2), IsCallbackAllowed = true, WorkerId = 1, ClientId = GetRandomClient().Id };
            db.ServiceToClients.Add(someServiceToClient);
            db.SaveChanges();


            for (int i = 0; i < 20; i++)
            {
                someServiceToClient = new ServiceToClient { ServiceTypeId = i % 2 + 1, UniqueKey = randomOp.GetSubstring(randomOp.getConfirmationCode(), 6), Assigned = DateTime.Now.AddMinutes(i * 5), IsCallbackAllowed = true, WorkerId = i % 15 + 1, ClientId = GetRandomClient().Id };
                db.ServiceToClients.Add(someServiceToClient);
                db.SaveChanges();

                if (DateTime.Now.Millisecond % 8 < 3)
                {
                    someServiceToClient.Value = -1;
                    someServiceToClient.ValueSet = someServiceToClient.Assigned.Value.AddMinutes(2);
                    someViolationFound = new FoundViolation { ServiceToClientId = someServiceToClient.Id, ViolationTypeId = i % 4 + 1 };
                    db.FoundViolations.Add(someViolationFound);
                    db.SaveChanges();
                    someServiceToClient.ClientFeedback = "";
                    db.Entry(someServiceToClient).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else if (DateTime.Now.Millisecond % 8 == 7)
                {
                    someServiceToClient.Value = 1;
                    someServiceToClient.ValueSet = someServiceToClient.Assigned.Value.AddMinutes(2);

                    db.Entry(someServiceToClient).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

            }

            for (int i = 0; i < 20; i++)
            {
                someServiceToClient = new ServiceToClient { ServiceTypeId = i % 3 + 1, UniqueKey = randomOp.GetSubstring(randomOp.getConfirmationCode(), 6), Assigned = DateTime.Now.AddMinutes(i * 7), IsCallbackAllowed = true, WorkerId = i % 14 + 1, ClientId = GetRandomClient().Id };
                db.ServiceToClients.Add(someServiceToClient);
                db.SaveChanges();

                if (DateTime.Now.Millisecond % 8 < 3)
                {
                    someServiceToClient.Value = -1;
                    someServiceToClient.ValueSet = someServiceToClient.Assigned.Value.AddMinutes(2);
                    someViolationFound = new FoundViolation { ServiceToClientId = someServiceToClient.Id, ViolationTypeId = i % 4 + 1 };
                    db.FoundViolations.Add(someViolationFound);
                    db.SaveChanges();
                    someServiceToClient.ClientFeedback = "";
                    db.Entry(someServiceToClient).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else if (DateTime.Now.Millisecond % 8 == 7)
                {
                    someServiceToClient.Value = 1;
                    someServiceToClient.ValueSet = someServiceToClient.Assigned.Value.AddMinutes(2);

                    db.Entry(someServiceToClient).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

            }

            for (int i = 0; i < 20; i++)
            {
                someServiceToClient = new ServiceToClient { ServiceTypeId = i % 3 + 1, UniqueKey = randomOp.GetSubstring(randomOp.getConfirmationCode(), 6), Assigned = DateTime.Now.AddMinutes(i * 8), IsCallbackAllowed = true, WorkerId = i % 15 + 1, ClientId = GetRandomClient().Id };
                db.ServiceToClients.Add(someServiceToClient);
                db.SaveChanges();

                if (DateTime.Now.Millisecond % 8 < 3)
                {
                    someServiceToClient.Value = -1;
                    someServiceToClient.ValueSet = someServiceToClient.Assigned.Value.AddMinutes(2);
                    someViolationFound = new FoundViolation { ServiceToClientId = someServiceToClient.Id, ViolationTypeId = i % 4 + 1 };
                    db.FoundViolations.Add(someViolationFound);
                    db.SaveChanges();
                    someServiceToClient.ClientFeedback = "";
                    db.Entry(someServiceToClient).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else if (DateTime.Now.Millisecond % 8 == 7)
                {
                    someServiceToClient.Value = 1;
                    someServiceToClient.ValueSet = someServiceToClient.Assigned.Value.AddMinutes(2);

                    db.Entry(someServiceToClient).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }

            for (int i = 0; i < 20; i++)
            {
                someServiceToClient = new ServiceToClient { ServiceTypeId = i % 2 + 1, UniqueKey = randomOp.GetSubstring(randomOp.getConfirmationCode(), 6), Assigned = DateTime.Now.AddMinutes(i * 10), IsCallbackAllowed = true, WorkerId = i % 12 + 1, ClientId = GetRandomClient().Id };
                db.ServiceToClients.Add(someServiceToClient);
                db.SaveChanges();

                if (DateTime.Now.Millisecond % 8 < 3)
                {
                    someServiceToClient.Value = -1;
                    someServiceToClient.ValueSet = someServiceToClient.Assigned.Value.AddMinutes(2);
                    someViolationFound = new FoundViolation { ServiceToClientId = someServiceToClient.Id, ViolationTypeId = i % 4 + 1 };
                    db.FoundViolations.Add(someViolationFound);
                    db.SaveChanges();
                    someServiceToClient.ClientFeedback = "";
                    db.Entry(someServiceToClient).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else if (DateTime.Now.Millisecond % 8 == 7)
                {
                    someServiceToClient.Value = 1;
                    someServiceToClient.ValueSet = someServiceToClient.Assigned.Value.AddMinutes(2);

                    db.Entry(someServiceToClient).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }

            db.Dispose();

            #endregion

        }


        private AspNetUser GetRandomClient()
        {
            PralnaEntities db = new PralnaEntities();
            IEnumerable<AspNetUser> someAspnetUsers = db.AspNetUsers.Where(m => m.Workers.Any() == false);
            int count = someAspnetUsers.Count();
            Random rnd = new Random();
            int n = rnd.Next(count-1);
            return someAspnetUsers.ToList().ElementAt(n);
        }

    }
}
