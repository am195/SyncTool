﻿using System;
using System.Collections;
using System.Linq;

namespace SyncTool
{
    class PBOList : ArrayList
    {
        //the return list contains a list of files not present in the remote repo (Deletion List)
        public PBOList DeleteList(PBOList remote)
        {
            PBOList diff = this;

            foreach (PBO diffPBO in diff)
                foreach (PBO remotePBO in remote)
                    if (remotePBO.hash == diffPBO.hash)
                        diff.Remove(diffPBO);

            return diff;
        }

        //the return list contains a list of files not present in the local repo (Download List)
        public PBOList DownloadList(PBOList remote)
        {
            PBOList diff = this;

            foreach (PBO remotePBO in remote)
                foreach (PBO diffPBO in diff)
                    if (remotePBO.hash == diffPBO.hash)
                        diff.Remove(diffPBO);

            return diff;
        }
    }
}
