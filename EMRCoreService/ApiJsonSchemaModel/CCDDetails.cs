using System;
using System.Collections.Generic;
using System.Text;

namespace EMRCoreService.ApiJsonSchemaModel
{

    public class CCD
    {
        public string AffiliationID { get; set; }
        public string ChartType { get; set; }
        public int[] DocumentData { get; set; }
        public string DocumentName { get; set; }
        public string FileType { get; set; }
        public string FormatReceivedFromVendor { get; set; }
        public Medicalcodes MedicalCodes { get; set; }
        public string MemberDOB { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberKey { get; set; }
        public string MemberKeyType { get; set; }
        public string MemberLastName { get; set; }
        public string NPI { get; set; }
        public string OriginalFileName { get; set; }
        public string ProviderFirstName { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderLastName { get; set; }
        public string ProviderMiddleName { get; set; }
        public string TIN { get; set; }
        public string TemporaryFileName { get; set; }
        public string UUID { get; set; }
        public string VendorKey { get; set; }
        public string VendorName { get; set; }
    }

    public class Medicalcodes
    {
        public string CodeType { get; set; }
        public string DateOfService { get; set; }
        public string Value { get; set; }
    }

}
