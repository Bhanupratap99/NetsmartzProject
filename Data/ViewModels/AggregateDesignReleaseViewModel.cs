using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class AggregateDesignReleaseViewModel
    {
        public int S_No { get; set; }
        public string PART_NO { get; set; }
        public string PART_DESCRIPTION { get; set; }
        public string PART_CATEGORY { get; set; }
        public string AGGREGATE { get; set; }
        public string COMMODITY { get; set; }


        // public string RELEASE_STATUS { get; set; }    // Columns to be added in the database
       
       
        public string L0_RELEASE { get; set; }
        public string SOURCING_CLOSURE { get; set; }
        public string ME_CLOSURE { get; set; }
        public string DESIGNER_REMARKS { get; set; }
        public string PROP_PART { get; set; }

        // public string SUPPLIER_DVP_SIGN_OFF { get; set; }   // Columns to be added in the database
        public string RELEASE_STAGE { get; set; }
        public string QUANTITY_TRACTOR { get; set; }

        // public string RM_QUANTITY_REQUIREMENT { get; set; }    // Columns to be added in the database

        public string PLATFORM_CODE { get; set; }
        public string PROJECT_CODE { get; set; }
        public string PROJECT_DESCRIPTION { get; set; }
        public string PART_REVISION { get; set; }
        public string SUBCATEGORY { get; set; }
        public string FAILUREMODE_REFERENCENO { get; set; }
        public string PART_CURRENTSTATUS { get; set; }
        public string ACTIVATING_RM { get; set; }
        public string ACTIVATING_RMDATE { get; set; }
        public string INACTIVATING_RM { get; set; }
        public string INACTIVATING_RMDATE { get; set; }
        public string PREVIOUS_PARTNO { get; set; }
        public string SRC_FEEDBACK_COMMENTS { get; set; }
        public string RND_COMMENTS { get; set; }
    }
}
