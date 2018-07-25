# SafeMedia
Hate speech and online violence are rampant nowadays, SafeMedia mean to make social media a safe place for everyone!

# Inspiration
While the 2019 General election is approaching in our country Nigeria, one of the most mitigating factors against the peaceful co-existence of the nation of different tribes and multiple religions and aggravate our democratic governance is hate speech and online violence. 

Hate speech and online violence result in many numbers of crises in Nigeria that claims thousands of lives and properties worth billions of dollars across its regions. Different attempts have been made by Government and nongovernmental organizations to mitigate if not eliminate the act among its citizens hence the Nigerian Government passed a bill that makes hate speech as an act of terrorism.

Fortunately, Nigeria is a diverse country that comprises hundreds of tribes and numerous religious thoughts and beliefs these factors results in natural disharmony among the citizens, when someone said something according to his belief and thoughts others might feel offended.

Our research is aim to help and promote nonuse of any form of hate speech in social media and to assist social media users on what to write and what to read that will not offend them or others. Also to provide analytic data to security concerns on hate speech and online violence.  

# What it does
SafeMedia asks user's Facebook permissions to post on his behalf and also read his page messages. Safemiedia helps users to write a non-hate speech on their Facebook wall and also read their page messages safely and hide any hate speech message. If a user feels any message or post contain hate speech and the system didn't recognize it, a user can instantly report that message or post as hate speech. 

# How We built it
We collected and gathered more than 10,000+ social media post from various social media users of the two most spoken languages in Nigeria (Hausa and English) that include both hate and not hate speech. However, we wrote a sentiment analysis algorithm using ML.NET machine learning framework with 84% accuracy to predict hate speech in the two languages.

# Challenges We ran into
Due to recent data privacy laws that enforce social media giants change their data sharing policy, we find it difficult to find a tool that will generate the data to train our model. Most of the public data we got is not the target language (Hausa) hence we collect more than 5,000+ Hausa post manually from social media platforms. Also, the initial schema we design to work with has so many data inputs to the extent that to fill a single row it will take you more than 5 minutes, after all, we design a simple schema that we use to collect more than 6,000+ data manually from social media.

# Accomplishments that We are proud of
1. 

# What we learned
Me muka Koya

# What's next for SafeMedia
Our next iteration in the roadmap is to support other Nigerian languages such as
* Yoruba
* Igbo
* Kanuri
Also to support other social media platforms like
* Twitter
* Instagram
* Google Plus

# Built With
* ML.NET (Machine Learning framework)
* React.js 
* Facebook Login SDK
* Facebook Graph API