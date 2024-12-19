namespace BusinessObject
{
    public class MemberWithRole : Member
    {
        public MemberWithRole(Member member)
        {
            Email = member.Email;
            MemberId = member.MemberId;
        }

        public MemberWithRole()
        {
        }

        public string MemberRoleString { get; set; }
    }
}
