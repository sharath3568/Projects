using System;
using Library_Book_Management_System.Entities;

namespace Library_Book_Management_System.Managers
{
    public class MemberManager
    {
        private Member[] memberList;
        private int count = 0;
        public MemberManager(int size)
        {
            memberList = new Member[size];
        }

        /// <summary>
        /// Checks whether there is space to add more Members.
        /// </summary>
        public bool HasCapacity()
        {
            return memberList.Contains(null);
        }

        public bool AddMember(Member member)
        {
            for(int i = 0; i < memberList.Length; i++)
            {
                if (memberList[i] == null)
                {
                    member.SetMemberID($"M{count + 1:D3}");
                    memberList[i] = member;
                    count++;
                    return true;
                }
            }
            return false;
        }

        public Member GetMemberByID(string memberID)
        {
            memberID = memberID.ToUpper();
            if (string.IsNullOrWhiteSpace(memberID))
                return null;

            for(int i = 0; i < memberList.Length; i++)
            {
                if (memberList[i] != null && memberList[i].MemberID == memberID)
                {
                    return memberList[i];
                }
            }
            return null;
        }

        public bool MemberExists(string memberID)
        {
            Member member = GetMemberByID(memberID);

            if(member != null)
            {
                return true;
            }
            return false;
        }

        public bool CanIssueBook(string memberID)
        {
            Member member = GetMemberByID(memberID);

            if(member != null && member.CanIssueBook())
            {
                return true;
            }
            return false;
        }

        public bool IncrementIssuedCount(string memberID)
        {
            Member member = GetMemberByID(memberID);
            if (member != null && member.CanIssueBook())
            {
                member.IncrementIssueCount();
                return true;
            }
            return false;
        }

        public bool DecrementIssuedCount(string memberID)
        {
            Member member = GetMemberByID(memberID);

            if(member == null)
            {
                return false;
            }

            try
            {
                member.DecrementIssueCount();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Member[] ViewAllMembers()
        {
            return memberList;
        }
        
        public bool DeleteMember(string memberID)
        {
            for(int i = 0; i <  memberList.Length; i++)
            {
                if(memberID != null && memberList[i].MemberID == memberID.ToUpper())
                {
                    if (memberList[i].CurrentIssuedCount > 0)
                    {
                        return false;
                    }

                    memberList[i] = null;
                    return true;
                }
            }
            return false;
        }
    }
}
