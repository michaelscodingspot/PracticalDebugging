using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks.Serializers
{
    public class Models
    {
        private const int ITEMS = 1000;
        public class ThousandSmallClassList
        {
            public List<SmallClass> List { get; set; }
            public ThousandSmallClassList()
            {
                List = new List<SmallClass>(Enumerable.Range(0,ITEMS).Select(x => new SmallClass()));
            }
        }

        public class ThousandSmallClassArray
        {
            public SmallClass[] Arr { get; set; }
            public ThousandSmallClassArray()
            {
                Arr = new List<SmallClass>(Enumerable.Range(0,ITEMS).Select(x => new SmallClass())).ToArray();
            }
        }

        public class ThousandSmallClassDictionary
        {
            public Dictionary<string, SmallClass> Dict { get; set; }
            public ThousandSmallClassDictionary()
            {
                Dict = new Dictionary<string, SmallClass>(Enumerable.Range(0, ITEMS)
                    .Select(x => new { Num = x, Obj = new SmallClass()})
                    .Select(anon => new KeyValuePair<string, SmallClass>(anon.Obj.Name + anon.Num.ToString(), anon.Obj)));
            }
        }
        
        public class SmallClass
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public int NumPurchases { get; set; }
            [DataMember]
            public bool IsVIP { get; set; }

            public SmallClass()
            {
                Name = "Bill Gates";
                NumPurchases = 1200;
                IsVIP = true;
            }
        }

        // BigClass
        public class BigClass
        {
            public BigClass()
            {
                Id = 1;
                ClubMembershipType = ClubMembershipTypes.Platinum;
                Gender = Gender.Female;
                FirstName = "Louise";
                MiddleInitial = "C";
                Surname = "Midgett";
                Address = new Address
                {
                    StreetAddress = "43 Compare Valley",
                    City = "Chambersburg",
                    State = "PA",
                    ZipCode = 17201,
                    Country = "US"
                };
                EmailAddress = "LouiseCMidgett@dodgit.com";
                TelephoneNumber = "717-261-7855";
                MothersMaiden = "Kelly";
                NextBirthday = Convert.ToDateTime("1-May-84");
                CCType = "Visa";
                CaseFileID = "192-80-6448";
                UPS = "1Z W64 924 70 0191 812 7";
                Occupation = "Traffic technician";
                Domain = "ScottsdaleSkincare.com";
                MembershipLevel = "A+";
                Kilograms = "64.2";
            }

            public string FullName { get; set; }

            public int Id { get; set; }
            public Gender Gender { get; set; }
            public string FirstName { get; set; }
            public string MiddleInitial { get; set; }
            public string Surname { get; set; }
            public string EmailAddress { get; set; }
            public string TelephoneNumber { get; set; }
            public string MothersMaiden { get; set; }

            public DateTime NextBirthday { get; set; }
            public string CCType { get; set; }
            public string CaseFileID { get; set; }
            public string UPS { get; set; }
            public string Occupation { get; set; }
            public string Domain { get; set; }
            public string MembershipLevel { get; set; }
            public string Kilograms { get; set; }

            private int _pendingInvoiceID;
        

            public int PendingInvoiceID
            {
                get { return _pendingInvoiceID; }
                set { _pendingInvoiceID = value; }
            }

            public Address Address { get; set; }
            public ClubMembershipTypes ClubMembershipType { get; set; }
            public int YearsAsCustomer { get { return 5;  } }

            public double GetYearlyEarnings(int year)
            {
                return year * 2;
            }

            internal int GetTotalMoneySpentAtStoreInUSD()
            {
                return ((int)FirstName[0])*50;
            }
        }

        public enum Gender
        {
            Male, Female
        }

        public enum ClubMembershipTypes
        {
            Premium, Platinum
        }

        public class Address
        {
            public string StreetAddress { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public int ZipCode { get; set; }
            public string Country { get; set; }
        }
        // -- end of BigClass
    }
}
