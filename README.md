The Guy Game (2004, PS2/PC/Xbox) PC release obfuscates the 998 .avi files used in the game.  This code deobfuscates them so they can be viewed in e.g. VLC.

The code loops through every .avi found in the subfolders of the given folder, removing the obfuscation.  It edits the files in place, so make sure you have them on a writable drive.  As this code will modify files on your PC, use it at your own risk.

Each round of the game is stored in a subfolder.  The naming convention appears to be:

/Final/Video/08/            <- round 08

/Final/Video/08/08_mth1.avi <- intro to contestant 1

/Final/Video/08/08_01q.avi  <- question 1

/Final/Video/08/08_01a0.avi <- correct answer

/Final/Video/08/08_01a1.avi <- incorrect answer, obscured by logo

/Final/Video/08/08_01a2.avi <- incorrect answer, blurred

/Final/Video/08/08_01a3.avi <- incorrect answer, uncensored

/Final/Video/08/08_hca.avi  <- challenge intro

/Final/Video/08/08_hcb.avi  <- challenge
