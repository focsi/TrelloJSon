using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloJSon.JSonClasses
{

    public class Rootobject
    {
        public string id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public object descData { get; set; }
        public bool closed { get; set; }
        public string idOrganization { get; set; }
        public bool invited { get; set; }
        public bool pinned { get; set; }
        public bool starred { get; set; }
        public string url { get; set; }
        public Prefs prefs { get; set; }
        public object[] invitations { get; set; }
        public Membership[] memberships { get; set; }
        public string shortLink { get; set; }
        public bool subscribed { get; set; }
        public Labelnames labelNames { get; set; }
        public object[] powerUps { get; set; }
        public DateTime dateLastActivity { get; set; }
        public DateTime dateLastView { get; set; }
        public string shortUrl { get; set; }
        public object[] idTags { get; set; }
        public object datePluginDisable { get; set; }
        public Action[] actions { get; set; }
        public Card1[] cards { get; set; }
        public Label1[] labels { get; set; }
        public List1[] lists { get; set; }
        public Member1[] members { get; set; }
        public object[] checklists { get; set; }
        public object[] pluginData { get; set; }
    }

    public class Prefs
    {
        public string permissionLevel { get; set; }
        public string voting { get; set; }
        public string comments { get; set; }
        public string invitations { get; set; }
        public bool selfJoin { get; set; }
        public bool cardCovers { get; set; }
        public string cardAging { get; set; }
        public bool calendarFeedEnabled { get; set; }
        public string background { get; set; }
        public object backgroundImage { get; set; }
        public object backgroundImageScaled { get; set; }
        public bool backgroundTile { get; set; }
        public string backgroundBrightness { get; set; }
        public string backgroundColor { get; set; }
        public bool canBePublic { get; set; }
        public bool canBeOrg { get; set; }
        public bool canBePrivate { get; set; }
        public bool canInvite { get; set; }
    }

    public class Labelnames
    {
        public string green { get; set; }
        public string yellow { get; set; }
        public string orange { get; set; }
        public string red { get; set; }
        public string purple { get; set; }
        public string blue { get; set; }
        public string sky { get; set; }
        public string lime { get; set; }
        public string pink { get; set; }
        public string black { get; set; }
    }

    public class Membership
    {
        public string id { get; set; }
        public string idMember { get; set; }
        public string memberType { get; set; }
        public bool unconfirmed { get; set; }
        public bool deactivated { get; set; }
    }

    public class Action
    {
        public string id { get; set; }
        public string idMemberCreator { get; set; }
        public Data data { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public Membercreator memberCreator { get; set; }
    }

    public class Data
    {
        public Listafter listAfter { get; set; }
        public Listbefore listBefore { get; set; }
        public Board board { get; set; }
        public Card card { get; set; }
        public Old old { get; set; }
        public List list { get; set; }
        public string text { get; set; }
        public Member member { get; set; }
        public Plugin plugin { get; set; }
        public Organization organization { get; set; }
    }

    public class Listafter
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Listbefore
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Board
    {
        public string shortLink { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Card
    {
        public string shortLink { get; set; }
        public int idShort { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string idList { get; set; }
        public int pos { get; set; }
    }

    public class Old
    {
        public string idList { get; set; }
        public int pos { get; set; }
        public string name { get; set; }
    }

    public class List
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Member
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Plugin
    {
        public string url { get; set; }
        public bool _public { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Organization
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Membercreator
    {
        public string id { get; set; }
        public string avatarHash { get; set; }
        public string fullName { get; set; }
        public string initials { get; set; }
        public string username { get; set; }
    }

    public class Card1
    {
        public string id { get; set; }
        public object checkItemStates { get; set; }
        public bool closed { get; set; }
        public DateTime dateLastActivity { get; set; }
        public string desc { get; set; }
        public object descData { get; set; }
        public string idBoard { get; set; }
        public string idList { get; set; }
        public object[] idMembersVoted { get; set; }
        public int idShort { get; set; }
        public object idAttachmentCover { get; set; }
        public bool manualCoverAttachment { get; set; }
        public string[] idLabels { get; set; }
        public string name { get; set; }
        public int pos { get; set; }
        public string shortLink { get; set; }
        public Badges badges { get; set; }
        public bool dueComplete { get; set; }
        public object due { get; set; }
        public string email { get; set; }
        public object[] idChecklists { get; set; }
        public object[] idMembers { get; set; }
        public Label[] labels { get; set; }
        public string shortUrl { get; set; }
        public bool subscribed { get; set; }
        public string url { get; set; }
        public object[] attachments { get; set; }
        public object[] pluginData { get; set; }
    }

    public class Badges
    {
        public int votes { get; set; }
        public bool viewingMemberVoted { get; set; }
        public bool subscribed { get; set; }
        public string fogbugz { get; set; }
        public int checkItems { get; set; }
        public int checkItemsChecked { get; set; }
        public int comments { get; set; }
        public int attachments { get; set; }
        public bool description { get; set; }
        public object due { get; set; }
        public bool dueComplete { get; set; }
    }

    public class Label
    {
        public string id { get; set; }
        public string idBoard { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public int uses { get; set; }
    }

    public class Label1
    {
        public string id { get; set; }
        public string idBoard { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public int uses { get; set; }
    }

    public class List1
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool closed { get; set; }
        public string idBoard { get; set; }
        public int pos { get; set; }
        public bool subscribed { get; set; }
    }

    public class Member1
    {
        public string id { get; set; }
        public string avatarHash { get; set; }
        public string bio { get; set; }
        public object bioData { get; set; }
        public bool confirmed { get; set; }
        public string fullName { get; set; }
        public object[] idPremOrgsAdmin { get; set; }
        public string initials { get; set; }
        public string memberType { get; set; }
        public object[] products { get; set; }
        public string status { get; set; }
        public string url { get; set; }
        public string username { get; set; }
    }

}