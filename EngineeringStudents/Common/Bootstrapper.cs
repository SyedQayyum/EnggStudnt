using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using ES.Biz.Contract;
using ES.Biz.Implementation;
using ES.DAL.Contract;
using ES.DAL.Implementation;
using System.Web.Http;

namespace EngineeringStudents.Common
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers


            #region Biz Layer
            container.RegisterType<ICommonBizManager, CommonBizManager>();
            container.RegisterType<IHomeBizManager, HomeBizManager>();
            container.RegisterType<IOperatorBizManager, OperatorBizManager>();
            container.RegisterType<IQsPaperBizManager, QsPaperBizManager>();
            container.RegisterType<IAdvertisementBizManager, AdvertisementBizManager>();
            container.RegisterType<ISubjectBizManager, SubjectBizManager>();
            container.RegisterType<IDepartmentBizManager, DepartmentBizManager>();
            container.RegisterType<IResultBizManager, ResultBizManager>();
            container.RegisterType<IUniversityBizManager, UniversityBizManager>();
            container.RegisterType<ISyllabusBizManager, SyllabusBizManager>();
            container.RegisterType<ICollegeBizManager, CollegeBizManager>();
            container.RegisterType<IContactBizManager, ContactBizManager>();
            


            
            #endregion

            #region Data Acess


            container.RegisterType<ICommonDataManager, CommonDataManager>();
            container.RegisterType<IHomeDataManager, HomeDataManager>();
            container.RegisterType<IOperatorDataManager, OperatorDataManager>();
            container.RegisterType<IQsPaperDataManager, QsPaperDataManager>();
            container.RegisterType<IAdvertisementDataManager, AdvertisementDataManager>();
            container.RegisterType<ISubjectDataManager, SubjectDataManager>();
            container.RegisterType<IDepartmentDataManager, DepartmentDataManager>();
            container.RegisterType<IResultDataManager, ResultDataManager>();
            container.RegisterType<IUniversityDataManager, UniversityDataManager>();
            container.RegisterType<ISyllabusDataManager, SyllabusDataManager>();
            container.RegisterType<ICollegeDataManager, CollegeDataManager>();
            container.RegisterType<IContactDataManager, ContactDataManager>();
            

            
            #endregion
            
            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}