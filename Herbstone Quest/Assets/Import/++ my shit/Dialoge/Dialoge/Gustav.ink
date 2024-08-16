=== Gustav ===
= Introduction
<color=\#a6c206>Gustav</color>: <b><color=\#32a852>ROBEUS</color></b> what a pleasure to see You here!
<color=\#a6c206>Gustav</color>: How may I be of service?
<color=\#32a852>ROBEUS</color>: I am looking for work.
-> QuestionONE

= QuestionONE
<color=\#a6c206>Gustav</color>: Mhm work You say? I might have some Quests for you.

* [Stones] -> QuestStones
* [Crystals] -> QuestCrystals
+ [No Interest] -> NoInterest

= QuestStones
<color=\#32a852>ROBEUS</color>: Do you need more Stones for your Rock Collection?
<color=\#a6c206>Gustav</color>: Yes, actually now I remember. Please get me some!
~ Event("StartQuest_CollectStones")
-> END

= QuestCrystals
<color=\#32a852>ROBEUS</color>: Do you need more Stones for your Rock Collection?
<color=\#a6c206>Gustav</color>: Yes, actually now I remember. Please get me some!
~ Event("StartQuest_CollectCrystals")
-> END

= NoInterest
<color=\#32a852>ROBEUS</color>: Not this time. Sorry.
<color=\#a6c206>Gustav</color>: That's alright. Come back when you change your mind
-> END


= WaitOnStones
<color=\#a6c206>Gustav</color>: You don't have enough <b><color=\#be73ff>Stones</color></b> yet!
-> END

= WaitOnCrystals
<color=\#a6c206>Gustav</color>: You don't have enough <b><color=\#be73ff>Crystals</color></b> yet!
-> END

= TradeCrystals
<color=\#a6c206>Gustav</color>: Great You've collected enough <b><color=\#be73ff>Crystals</color></b>!
<color=\#a6c206>Gustav</color>: Here are some special <b><color=\#ffd500>Crystals</color></b> for your Help:
~ Event("FinishQuest_CollectCrystals")
<color=\#32a852>ROBEUS</color>: Thank You!
-> END

= TradeStones
<color=\#a6c206>Gustav</color>: Great You've collected enough <b><color=\#be73ff>Stones</color></b>!
<color=\#a6c206>Gustav</color>: Here are some special <b><color=\#ffd500>Crystals</color></b> for your Help:
~ Event("FinishQuest_CollectStones")
<color=\#32a852>ROBEUS</color>: Thank You!
-> END

= NoMoreTalk
<color=\#a6c206>Gustav</color>: I dont have any more Quests for you yet. Don't be so impatient!
-> END

= Backup
<color=\#a6c206>Gustav</color>: I can't remember this place..
-> END