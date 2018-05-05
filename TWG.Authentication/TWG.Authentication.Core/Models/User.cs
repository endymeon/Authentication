using System;
using TWG.Authentication.Core.Enums;

namespace TWG.Authentication.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
    }
}