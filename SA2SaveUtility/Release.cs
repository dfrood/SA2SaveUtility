using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA2SaveUtility
{

    public class Release
    {
        public string url;
        public string assets_url;
        public string upload_url;
        public string html_url;
        public string id;
        public string node_id;
        public string tag_name;
        public string target_commitish;
        public string name;
        public string draft;
        public User author;
        public string prerelease;
        public string created_at;
        public string published_at;
        public List<Assets> assets;
        public string tarball_url;
        public string zipball_url;
        public string body;
    }

    public class User
    {
        public string login;
        public string id;
        public string node_id;
        public string avatar_url;
        public string gravatar_id;
        public string url;
        public string html_url;
        public string followers_url;
        public string following_url;
        public string gists_url;
        public string starred_url;
        public string subscriptions_url;
        public string organizations_url;
        public string repos_url;
        public string events_url;
        public string received_events_url;
        public string type;
        public string site_admin;
    }

    public class Assets
    {
        public string url;
        public string id;
        public string node_id;
        public string name;
        public string label;
        public User uploader;
        public string content_type;
        public string state;
        public string size;
        public string download_count;
        public string created_at;
        public string updated_at;
        public string browser_download_url;
    }

}
