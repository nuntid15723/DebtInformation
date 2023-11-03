namespace DebtInformation.Models
{
    public class Informations_test
    {
        public string? coop_id { get; set; }
        public string? memcoop_id { get; set; }
        public string member_no { get; set; }
        public string membcat_code { get; set; }
        public string deptaccount_no { get; set; }
        public string deptaccount_name { get; set; }
        public string dept_objective { get; set; }
        public string depttype_desc { get; set; }
        public string deptgroup_code { get; set; }
        public string moneytype_code { get; set; }
        public string bank_code { get; set; }
        public string entry_id { get; set; }
        public string machine_id { get; set; }
        public string cash_type { get; set; }
        public List<Recppaytype> recppaytype { get; set; }
        public List<Tofromacc> tofromacc { get; set; }
        public DateTime operate_date { get; set; }
        public string remark { get; set; }
        public string entry_date { get; set; }
        public string operate_code { get; set; }
        public string sign_flag { get; set; }
        public string laststmseq_no { get; set; }
        public string deptitem_amt { get; set; }
        public string fee_amt { get; set; }
        public string oth_amt { get; set; }
        public string prncbal { get; set; }
        public string withdrawable_amt { get; set; }
        public string prncbal_retire { get; set; }
    }
    public class Recppaytype
    {
        public string recppaytype_code { get; set; }
        public string recppaytype_desc { get; set; }
        public string cash_type { get; set; }
    }
    public class Tofromacc
    {
        public string tofromacc_id { get; set; }
        public string tofromacc_desc { get; set; }
        public string cash_type { get; set; }
    }


}
