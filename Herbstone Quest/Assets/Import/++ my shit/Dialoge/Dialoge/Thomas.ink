=== Thomas ===
= Introduction
<color=\#a6c206>Thomas</color>: Hi there <b><color=\#32a852>ROBEUS</color></b>!
<color=\#a6c206>Thomas</color>: How are you doing today?
-> QuestionONE

= QuestionONE
<color=\#a6c206>Thomas</color>: Can You get me some <b><color=\#be73ff>LAVENDAR</color></b>?

+ [Nahh] -> Nahh
+ [Sure] -> Sure

= Nahh
<color=\#32a852>ROBEUS</color>: Sorry, I'm busy right now.
<color=\#a6c206>Thomas</color>: Okay then. Maybe another Time
-> END

= Sure
<color=\#32a852>ROBEUS</color>: Of course I can. Where can I find those?
<color=\#a6c206>Thomas</color>: You will find them laying around outside!
~ Event("StartQuest_CollectLavendar")
-> END

= WaitingForLavendar
<color=\#32a852>ROBEUS</color>: Have You found enough <b><color=\#be73ff>LAVENDAR</color></b> yet?
-> END

= TradeLavendar
<color=\#a6c206>Thomas</color>: Nice you've collected enough <b><color=\#be73ff>LAVENDAR</color></b>!
<color=\#a6c206>Thomas</color>: Here are some <b><color=\#ffd500>Crystals</color></b> for your Help:
~ Event("FinishQuest_CollectLavendar")
<color=\#32a852>ROBEUS</color>: Thank You!
-> END

= NoMoreTalk
<color=\#a6c206>Yuffie</color>: I don't need <b><color=\#6632a8>LAVENDAR</color></b> right now.
-> END

= Backup
<color=\#a6c206>Thomas</color>: What am I even doing here?
-> END