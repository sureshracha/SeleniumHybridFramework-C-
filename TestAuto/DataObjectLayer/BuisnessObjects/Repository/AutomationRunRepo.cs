using DataObjectLayer.BuisnessObjects.Entites;
using DataObjectLayer.BuisnessObjects.Entitites;
using DataObjectLayer.BuisnessObjects.Entites;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer.BuisnessObjects.Util;

namespace DataObjectLayer.BuisnessObjects.Repository
{
     public class AutomationRunRepo:RepositoryBase
    {

        public AutomationRuns GetAutomationToRun()
        {
           return _session.CreateCriteria<AutomationRuns>().Add(Restrictions.Ge("RunDateTime", DateTime.Now)).Future<AutomationRuns>().FirstOrDefault();
        }
    }

    public class FeaturesRepo : RepositoryBase
    {
        public Features GetFeature(string FeatureName)
        {
            return _session.CreateCriteria<Features>().Add(Restrictions.Like("Feature", FeatureName,MatchMode.Anywhere)).Future<Features>().FirstOrDefault();
        }

        public Dictionary<string, int> GetAllFeatures()
        {
            var retDict = new Dictionary<string, int>();

            var fets = _session.CreateCriteria<Features>().Future<Features>().ToList();
            foreach (var item in fets)
            {
                retDict.Add(item.Feature, item.Featureid);
            }

            return retDict;
        }


    }

    public class EnvironmentRepo:RepositoryBase
    {
        public Environments GetEnvById(int id)
        {
            return _session.CreateCriteria<Environments>().Add(Restrictions.Eq("envid", id)).Future<Environments>().FirstOrDefault();
        }

        public List<Environments> GetAllEnvironments()
        {
            return _session.CreateCriteria<Environments>().Future<Environments>().ToList();
        }
    }

    public class WorkListFilterFieldsRepo : RepositoryBase
    {
        public WorkListFilterFields GetRandom()
        {
            return _session.CreateQuery("from WorkListFilterFields order by newid()").SetMaxResults(1).Future<WorkListFilterFields>().FirstOrDefault();
        }

        public List<AdditionalFilterParms> GetAdditionalParmsByFieldId(int fieldId)
        {
            //return _session.CreateQuery("from AdditionalFilter Parms where ")
            return _session.CreateCriteria<AdditionalFilterParms>().Add(Restrictions.Eq("FieldId", fieldId)).Future<AdditionalFilterParms>().ToList();
        }
    }


    public class EFRAutoResultsRepo : RepositoryBase
    {
        public List<EFRAutoResults> GetAutomationResults(int featureId,DateTime? startTime = null, DateTime? endTime = null, string machineName = null  )
        {
            //return _session.CreateCriteria<EFRAutoResults>().Add(Restrictions.Between("ExecutionTime", startTime, endTime))
            //        .Add(Restrictions.Eq("FeatureId", featureId)).Future<EFRAutoResults>().ToList();
            var sql = _session.CreateCriteria<EFRAutoResults>().Add(Restrictions.Eq("FeatureId", featureId));
            if (startTime.HasValue && endTime.HasValue)
            {
                sql.Add(Restrictions.Between("ExecutionTime", startTime, endTime));
            }
            return sql.Future<EFRAutoResults>().ToList();
        }

        public List<EFRAutoResults> GetAutomationResultsByCriteria(List<Criteria> scc)
        {
            //return _session.CreateCriteria<EFRAutoResults>().Add(Restrictions.Between("ExecutionTime", startTime, endTime))
            //        .Add(Restrictions.Eq("FeatureId", featureId)).Future<EFRAutoResults>().ToList();
            var sql = _session.CreateCriteria<EFRAutoResults>();
            new Criterian().PropertyToCriteria(scc, sql);
            return sql.Future<EFRAutoResults>().ToList();
        }

        public EFRAutoResults GetResultsById(List<Criteria> scc)
        {
            var sql = _session.CreateCriteria<EFRAutoResults>();
            new Criterian().PropertyToCriteria(scc, sql);
            return sql.Future<EFRAutoResults>().FirstOrDefault();
        }


    }

}
