using DataObjectLayer.BuisnessObjects.Entites;
using DataObjectLayer.BuisnessObjects.Entitites;
using DataObjectLayer.BuisnessObjects.Repository;
using DataObjectLayer.BuisnessObjects.Entites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.BuisnessObjects
{
    public class DataObjects
    {

        public RepositoryBase repoBase = new RepositoryBase();
        public Environments env = new Environments();
        public List<Tasking> tasks = new List<Tasking>();
        public AdjustRefunds adjustRefund = new AdjustRefunds();
        public AutomationRuns run = new AutomationRuns();
        public string featureName = string.Empty;
        public Features retFeature = new Features();



        public void SetBoDataObject()
        {
            run = new AutomationRunRepo().GetAutomationToRun();
            if (run == null)
                Assert.Fail("There where no scheduled runs returned");
            retFeature = new FeaturesRepo().GetFeature(featureName);

            env = repoBase.ToList<Environments>().Where(x => x.regionId == run.regionid && x.sso == run.sso).FirstOrDefault();
        }

        public List<Tasking> GetTaskingObjects()
        {
            return tasks = repoBase.ToList<Tasking>().ToList();
        }

        public List<Users> GetUsers()
        {
            return repoBase.ToList<Users>().Where(x => x.Regionid == env.regionId && x.Sso == env.sso && x.FeatureId == retFeature.Featureid).OrderByDescending(x => x.Userid).ToList();
        }

        public Users GetUser()
        {
            return repoBase.ToList<Users>().Where(x => x.Regionid == env.regionId && x.Sso == run.sso && x.FeatureId == retFeature.Featureid).OrderByDescending(x => x.Userid).FirstOrDefault();
        }
    }
}
