﻿using System.Windows.Forms;
using GitUIPluginInterfaces;
using ResourceManager;

namespace Stash
{
    public class StashPlugin : GitPluginBase
    {
        public StashPlugin()
        {
            SetNameAndDescription("Create Stash Pull Request");
            Translate();
        }

        public static StringSetting StashUsername = new StringSetting("Stash Username", string.Empty);
        public static PasswordSetting StashPassword = new PasswordSetting("Stash Password", string.Empty);
        public static StringSetting StashBaseURL = new StringSetting("Specify the base URL to Stash", "https://example.stash.com");
        public static BoolSetting StashDisableSSL = new BoolSetting("Disable SSL verification", false);

        public override bool Execute(GitUIBaseEventArgs gitUiCommands)
        {
            using (var frm = new StashPullRequestForm(gitUiCommands, base.Settings))
                frm.ShowDialog(gitUiCommands.OwnerForm);
            return true;
        }

        public override System.Collections.Generic.IEnumerable<ISetting> GetSettings()
        {
            yield return StashUsername;
            yield return StashPassword;
            yield return StashBaseURL;
            yield return StashDisableSSL;
        }
    }
}
