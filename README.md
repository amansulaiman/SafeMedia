# SafeMedia
Hate speech and online violence are rampant nowadays, SafeMedia mean to make social media a safe place for everyone!

# Inspiration
As we are facing 2019 General election in our country Nigeria, one of the most mitigating factors against the peaceful co-existence of the nation of different tribes and multiple religions and aggravate our democratic governance in Nigeria is hate speech and online violence. 

Hate speech and online violence result in many numbers of crises in Nigeria that claims thousands of lives and properties worth billions of dollars across its regions. Different attempts have been made by Government and nongovernmental organizations to mitigate if not eliminate the act among its citizens hence the Nigerian Government passed a bill that makes hate speech as an act of terrorism.

Fortunately, Nigeria is a diverse country that comprises hundreds of tribes and numerous religious thoughts and beliefs these factors results in natural disharmony among the citizens, when someone said something according to his belief and thoughts others might feel offended.

Our research is aim to help and promote nonuse of any form of hate speech in social media and to assist social media users on what to write and what to read that will not offend them or others. Also to provide analytic data to security concerns on hate speech and online violence. 

# What it does
SafeMedia ask user's facebook permissions to read his/her feed any run AI tool to determine wether the feed data contain hate speech or not.  

# How We built it
We collected and gathered morethan 10,000+ post from various social media users of three most spoken languages oin Nigeria (English, Hausa, Yoruba) that include both hate and not hate speech. However, we wrote sentiment analysis algorithm using ML.NET machine learning framework with 90% accuracy to predict hate speech in three languages. 
After that, we build 

# Challenges We ran into
The most challanges we ran into is the data collection. Due to recent data provacy laws that enforce most of social media giants change theri policy on data sharing we find it diffucult to get a tool that will generate a data for us to train our model. Most of the public data we got are not hour main focus language (Hausa) hence we decided to collect morethan 5,000+ hausa post manually from social media platforms. Also, the schema we design to work with has so many data iputs to the extend that to fill a single row it will take you morethan 5 minutes, after all we design a siple shema that we use to collect morethan 6,000+ data manually from social media. 

# Accomplishments that We are proud of
Wanne abu muka cimma da muke alfahari da shi

# What we learned
Me muka koya

# What's next for SafeMedia
Our next iteration in the road map is to support other Nigerian languages such as
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

export ASPNETCORE_ENVIRONMENT=Development