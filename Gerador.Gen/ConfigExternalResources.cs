using Common.Gen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Gen
{
    public class ConfigExternalResources
    {

        private ExternalResource ConfigExternarResourcesTemplatesFrontAngularJs(bool replaceLocalFilesApplication) {

            return new ExternalResource
            {
                ReplaceLocalFilesApplication = replaceLocalFilesApplication,
                ResouceRepositoryName = "template-gerador-front-angularJS",
                ResourceUrlRepository = "https://github.com/wilsonsantosnet/template-gerador-front-angularJS.git",
                ResourceLocalPathFolderExecuteCloning = @"C:\Projetos\Outros\Repositorios",
                ResourceLocalPathDestinationFolrderApplication = @"C:\Projetos\Outros\Repositorios\seed-core-ddd-project-with-gerador\Gerador.Gen\Templates\Front",
            };

        }

        private ExternalResource ConfigExternarResourcesTemplatesBackDDD(bool replaceLocalFilesApplication) 
        {

            return new ExternalResource
            {
                ReplaceLocalFilesApplication = true,
                ResouceRepositoryName = "template-gerador-back-DDD",
                ResourceUrlRepository = "https://github.com/wilsonsantosnet/template-gerador-back-DDD.git",
                ResourceLocalPathFolderExecuteCloning = @"C:\Projetos\Outros\Repositorios",
                ResourceLocalPathDestinationFolrderApplication = @"C:\Projetos\Outros\Repositorios\seed-core-ddd-project-with-gerador\Gerador.Gen\Templates\Back"
            };

        }

        private ExternalResource ConfigExternarResourcesFrameworkAngulaJsCrud(bool replaceLocalFilesApplication)
        {

            return new ExternalResource
            {
                ReplaceLocalFilesApplication = true,
                ResouceRepositoryName = "framework-angularJS-CRUD",
                ResourceUrlRepository = "https://github.com/wilsonsantosnet/framework-angularJS-CRUD.git",
                ResourceLocalPathFolderExecuteCloning = @"C:\Projetos\Outros\Repositorios",
                ResourceLocalPathDestinationFolrderApplication = @"C:\Projetos\Outros\Repositorios\seed-core-ddd-project-with-gerador\Sample.Spa.Ui\js\common"
            };

        }

        private ExternalResource ConfigExternarResourcesFrameworkCommon(bool replaceLocalFilesApplication)
        {

            return new ExternalResource
            {
                ReplaceLocalFilesApplication = true,
                OnlyFoldersContainsThisName = "Common",
                ResouceRepositoryName = "framework-core-common",
                ResourceUrlRepository = "https://github.com/wilsonsantosnet/framework-core-common.git",
                ResourceLocalPathFolderExecuteCloning = @"C:\Projetos\Outros\Repositorios",
                ResourceLocalPathDestinationFolrderApplication = @"C:\Projetos\Outros\Repositorios\seed-core-ddd-project-with-gerador\"
            };

        }

        private ExternalResource ConfigExternarResourcesSeedLayout(bool replaceLocalFilesApplication)
        {

            return new ExternalResource
            {
                ReplaceLocalFilesApplication = true,
                DownloadOneTime = true,
                ResouceRepositoryName = "Seed-layout-front",
                ResourceUrlRepository = "https://github.com/wilsonsantosnet/Seed-layout-front.git",
                ResourceLocalPathFolderExecuteCloning = @"C:\Projetos\Outros\Repositorios",
                ResourceLocalPathDestinationFolrderApplication = @"C:\Projetos\Outros\Repositorios\seed-core-ddd-project-with-gerador\Sample.Spa.Ui"
            };

        }

        public IEnumerable<ExternalResource> GetConfigExternarReources()
        {
            var replaceLocalFilesApplication = true;

            return new List<ExternalResource>
            {
                ConfigExternarResourcesTemplatesFrontAngularJs(replaceLocalFilesApplication),
                ConfigExternarResourcesTemplatesBackDDD(replaceLocalFilesApplication),
                ConfigExternarResourcesFrameworkAngulaJsCrud(replaceLocalFilesApplication),
                ConfigExternarResourcesFrameworkCommon(replaceLocalFilesApplication),
                ConfigExternarResourcesSeedLayout(replaceLocalFilesApplication)

            };

        }


    }
}
