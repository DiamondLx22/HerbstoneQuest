=== Chayanne ===
= Introduction
<color=\#a6c206>Yuffie</color>: Hi there <b><color=\#32a852>ROBEUS</color></b>!
<color=\#a6c206>Yuffie</color>: How are you doing today?
-> QuestionONE

= QuestionONE
<color=\#a6c206>Yuffie</color>: I just bought these new sunglasses. Do you think they suit me?

* [Sure] -> Polite
* [Unsure] -> Unsure
+ [Absolutely!] -> Absolutely

= Absolutely
~ Event("Exited")
<color=\#32a852>ROBEUS</color>: They absolutely do!
<color=\#a6c206>Yuffie</color>: I know. Sadly this was the last pair of sunglasses they had. But I'll stay on lookout for you if I see some.
~ Event("Calm")
~ Event("No_Sunglasses")
-> END

= Unsure
<color=\#32a852>ROBEUS</color>: I'm not sure...
<color=\#a6c206>Yuffie</color>: I think they do. You should get some sunglasses too.
~ Event("Calm")
-> END

= Polite
<color=\#32a852>ROBEUS</color>: Uhm.. Yeah sure...
<color=\#a6c206>Yuffie</color>: You think so too? They're cool, you should get some as well!
~ Event("Calm")
-> END

= NoMoreTalk
<color=\#32a852>ROBEUS</color>: Hi, anything new?
<color=\#a6c206>Yuffie</color>: Sorry, I still haven't found a pair of sunglasses for you.
-> END

= Backup
<color=\#a6c206>Yuffie</color>: What am I even doing here?
-> END