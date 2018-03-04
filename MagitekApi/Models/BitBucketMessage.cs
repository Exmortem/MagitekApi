using System;
using System.Collections.Generic;

namespace MagitekApi.Models
{
    public class Commits
    {
        public string href { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Html
    {
        public string href { get; set; }
    }

    public class Links
    {
        public Commits commits { get; set; }
        public Self self { get; set; }
        public Html html { get; set; }
    }

    public class Self2
    {
        public string href { get; set; }
    }

    public class Html2
    {
        public string href { get; set; }
    }

    public class Links2
    {
        public Self2 self { get; set; }
        public Html2 html { get; set; }
    }

    public class Self3
    {
        public string href { get; set; }
    }

    public class Html3
    {
        public string href { get; set; }
    }

    public class Avatar
    {
        public string href { get; set; }
    }

    public class Links3
    {
        public Self3 self { get; set; }
        public Html3 html { get; set; }
        public Avatar avatar { get; set; }
    }

    public class User
    {
        public string username { get; set; }
        public string type { get; set; }
        public string display_name { get; set; }
        public string uuid { get; set; }
        public Links3 links { get; set; }
    }

    public class Author
    {
        public string raw { get; set; }
        public string type { get; set; }
        public User user { get; set; }
    }

    public class Summary
    {
        public string raw { get; set; }
        public string markup { get; set; }
        public string html { get; set; }
        public string type { get; set; }
    }

    public class Self4
    {
        public string href { get; set; }
    }

    public class Html4
    {
        public string href { get; set; }
    }

    public class Links4
    {
        public Self4 self { get; set; }
        public Html4 html { get; set; }
    }

    public class Parent
    {
        public string type { get; set; }
        public string hash { get; set; }
        public Links4 links { get; set; }
    }

    public class Target
    {
        public string hash { get; set; }
        public Links2 links { get; set; }
        public Author author { get; set; }
        public Summary summary { get; set; }
        public List<Parent> parents { get; set; }
        public DateTime date { get; set; }
        public string message { get; set; }
        public string type { get; set; }
    }

    public class Old
    {
        public string type { get; set; }
        public string name { get; set; }
        public Links links { get; set; }
        public Target target { get; set; }
    }

    public class Commits2
    {
        public string href { get; set; }
    }

    public class Html5
    {
        public string href { get; set; }
    }

    public class Diff
    {
        public string href { get; set; }
    }

    public class Links5
    {
        public Commits2 commits { get; set; }
        public Html5 html { get; set; }
        public Diff diff { get; set; }
    }

    public class Self5
    {
        public string href { get; set; }
    }

    public class Comments
    {
        public string href { get; set; }
    }

    public class Html6
    {
        public string href { get; set; }
    }

    public class Diff2
    {
        public string href { get; set; }
    }

    public class Approve
    {
        public string href { get; set; }
    }

    public class Statuses
    {
        public string href { get; set; }
    }

    public class Patch
    {
        public string href { get; set; }
    }

    public class Links6
    {
        public Self5 self { get; set; }
        public Comments comments { get; set; }
        public Html6 html { get; set; }
        public Diff2 diff { get; set; }
        public Approve approve { get; set; }
        public Statuses statuses { get; set; }
        public Patch patch { get; set; }
    }

    public class Self6
    {
        public string href { get; set; }
    }

    public class Html7
    {
        public string href { get; set; }
    }

    public class Avatar2
    {
        public string href { get; set; }
    }

    public class Links7
    {
        public Self6 self { get; set; }
        public Html7 html { get; set; }
        public Avatar2 avatar { get; set; }
    }

    public class User2
    {
        public string username { get; set; }
        public string type { get; set; }
        public string display_name { get; set; }
        public string uuid { get; set; }
        public Links7 links { get; set; }
    }

    public class Author2
    {
        public string raw { get; set; }
        public string type { get; set; }
        public User2 user { get; set; }
    }

    public class Summary2
    {
        public string raw { get; set; }
        public string markup { get; set; }
        public string html { get; set; }
        public string type { get; set; }
    }

    public class Self7
    {
        public string href { get; set; }
    }

    public class Html8
    {
        public string href { get; set; }
    }

    public class Links8
    {
        public Self7 self { get; set; }
        public Html8 html { get; set; }
    }

    public class Parent2
    {
        public string type { get; set; }
        public string hash { get; set; }
        public Links8 links { get; set; }
    }

    public class Commit
    {
        public string hash { get; set; }
        public Links6 links { get; set; }
        public Author2 author { get; set; }
        public Summary2 summary { get; set; }
        public List<Parent2> parents { get; set; }
        public DateTime date { get; set; }
        public string message { get; set; }
        public string type { get; set; }
    }

    public class Commits3
    {
        public string href { get; set; }
    }

    public class Self8
    {
        public string href { get; set; }
    }

    public class Html9
    {
        public string href { get; set; }
    }

    public class Links9
    {
        public Commits3 commits { get; set; }
        public Self8 self { get; set; }
        public Html9 html { get; set; }
    }

    public class Self9
    {
        public string href { get; set; }
    }

    public class Html10
    {
        public string href { get; set; }
    }

    public class Links10
    {
        public Self9 self { get; set; }
        public Html10 html { get; set; }
    }

    public class Self10
    {
        public string href { get; set; }
    }

    public class Html11
    {
        public string href { get; set; }
    }

    public class Avatar3
    {
        public string href { get; set; }
    }

    public class Links11
    {
        public Self10 self { get; set; }
        public Html11 html { get; set; }
        public Avatar3 avatar { get; set; }
    }

    public class User3
    {
        public string username { get; set; }
        public string type { get; set; }
        public string display_name { get; set; }
        public string uuid { get; set; }
        public Links11 links { get; set; }
    }

    public class Author3
    {
        public string raw { get; set; }
        public string type { get; set; }
        public User3 user { get; set; }
    }

    public class Summary3
    {
        public string raw { get; set; }
        public string markup { get; set; }
        public string html { get; set; }
        public string type { get; set; }
    }

    public class Self11
    {
        public string href { get; set; }
    }

    public class Html12
    {
        public string href { get; set; }
    }

    public class Links12
    {
        public Self11 self { get; set; }
        public Html12 html { get; set; }
    }

    public class Parent3
    {
        public string type { get; set; }
        public string hash { get; set; }
        public Links12 links { get; set; }
    }

    public class Target2
    {
        public string hash { get; set; }
        public Links10 links { get; set; }
        public Author3 author { get; set; }
        public Summary3 summary { get; set; }
        public List<Parent3> parents { get; set; }
        public DateTime date { get; set; }
        public string message { get; set; }
        public string type { get; set; }
    }

    public class New
    {
        public string type { get; set; }
        public string name { get; set; }
        public Links9 links { get; set; }
        public Target2 target { get; set; }
    }

    public class Change
    {
        public bool forced { get; set; }
        public Old old { get; set; }
        public Links5 links { get; set; }
        public bool truncated { get; set; }
        public List<Commit> commits { get; set; }
        public bool created { get; set; }
        public bool closed { get; set; }
        public New @new { get; set; }
    }

    public class Push
    {
        public List<Change> changes { get; set; }
    }

    public class Self12
    {
        public string href { get; set; }
    }

    public class Html13
    {
        public string href { get; set; }
    }

    public class Avatar4
    {
        public string href { get; set; }
    }

    public class Links13
    {
        public Self12 self { get; set; }
        public Html13 html { get; set; }
        public Avatar4 avatar { get; set; }
    }

    public class Actor
    {
        public string username { get; set; }
        public string type { get; set; }
        public string display_name { get; set; }
        public string uuid { get; set; }
        public Links13 links { get; set; }
    }

    public class Self13
    {
        public string href { get; set; }
    }

    public class Html14
    {
        public string href { get; set; }
    }

    public class Avatar5
    {
        public string href { get; set; }
    }

    public class Links14
    {
        public Self13 self { get; set; }
        public Html14 html { get; set; }
        public Avatar5 avatar { get; set; }
    }

    public class Self14
    {
        public string href { get; set; }
    }

    public class Html15
    {
        public string href { get; set; }
    }

    public class Avatar6
    {
        public string href { get; set; }
    }

    public class Links15
    {
        public Self14 self { get; set; }
        public Html15 html { get; set; }
        public Avatar6 avatar { get; set; }
    }

    public class Owner
    {
        public string username { get; set; }
        public string type { get; set; }
        public string display_name { get; set; }
        public string uuid { get; set; }
        public Links15 links { get; set; }
    }

    public class Repository
    {
        public string scm { get; set; }
        public string website { get; set; }
        public string name { get; set; }
        public Links14 links { get; set; }
        public string full_name { get; set; }
        public Owner owner { get; set; }
        public string type { get; set; }
        public bool is_private { get; set; }
        public string uuid { get; set; }
    }

    public class BitBucketMessage
    {
        public Push push { get; set; }
        public Actor actor { get; set; }
        public Repository repository { get; set; }
    }
}
