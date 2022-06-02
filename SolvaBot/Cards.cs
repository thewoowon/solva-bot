// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Web;

namespace SolvaBot
{
    public static class Cards
    {
       
        public static HeroCard GetHeroCard()
        {
            var heroCard = new HeroCard
            {
                Title = string.Empty,
                Subtitle = string.Empty,
                Text = string.Empty,
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return heroCard;
        }

        public static HeroCard GetQualityCard()
        {
            var qualityCard = new HeroCard
            {
                Title = "품질분석에 대해서 알아봅니다.",
                Subtitle = "어떤 것이 궁금하신가요?",
                Text = "품질분석은 QMS에서 OOO한 메뉴입니다." +
                       "가장 편한 품질 분석의 기회를 제공합니다.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return qualityCard;
        }
        public static HeroCard GetComplaintCard()
        {
            var complaintCard = new HeroCard
            {
                Title = "고객불만에 대해서 알아봅니다.",
                Subtitle = "어떤 것이 궁금하신가요?",
                Text = "고객물만은 QMS에서 OOO한 메뉴입니다." +
                       "가장 효율적인 고객 서비스 관리의 기회를 제공합니다.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return complaintCard;
        }
        public static HeroCard GetInspectionCard()
        {
            var inspectionCard = new HeroCard
            {
                Title = "검사관리에 대해서 알아봅니다.",
                Subtitle = "어떤 것이 궁금하신가요?",
                Text = "검사관리는 QMS에서 OOO한 메뉴입니다." +
                       "체계적인 검사관리로 제품의 질적향성을 기회를 제공합니다.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return inspectionCard;
        }
        public static HeroCard GetNonconformingCard()
        {
            var nonconformingCard = new HeroCard
            {
                Title = "부적합관리에 대해서 알아봅니다.",
                Subtitle = "어떤 것이 궁금하신가요?",
                Text = "부적합관리는 QMS에서 OOO한 메뉴입니다." +
                       "제품의 부적합을 데이터화하고 손실을 줄이는 기회를 제공합니다.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return nonconformingCard;
        }
        public static HeroCard GetJudgeCard()
        {
            var judgeCard = new HeroCard
            {
                Title = "심사관리에 대해서 알아봅니다.",
                Subtitle = "어떤 것이 궁금하신가요?",
                Text = "심사관리는 QMS에서 OOO한 메뉴입니다." +
                       "제품 결정에 대한 부가적인 기능를 제공합니다.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return judgeCard;
        }
        public static HeroCard GetChangeCard()
        {
            var ChangeCard = new HeroCard
            {
                Title = "변경관리에 대해서 알아봅니다.",
                Subtitle = "어떤 것이 궁금하신가요?",
                Text = "변경관리는 QMS에서 OOO한 메뉴입니다." +
                       "변경 이력의 체계적인 분석 기회를 제공합니다.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return ChangeCard;
        }
        public static HeroCard GetTestCard()
        {
            var testCard = new HeroCard
            {
                Title = "시험의뢰에 대해서 알아봅니다.",
                Subtitle = "어떤 것이 궁금하신가요?",
                Text = "시험의뢰는 QMS에서 OOO한 메뉴입니다." +
                       "제품 테스트 과정의 전반을 총괄하는 기는를 제공합니다.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return testCard;
        }
        public static HeroCard GetStandardCard()
        {
            var standardCard = new HeroCard
            {
                Title = "표준관리에 대해서 알아봅니다.",
                Subtitle = "어떤 것이 궁금하신가요?",
                Text = "표준관리는 QMS에서 OOO한 메뉴입니다." +
                       "제품 표준에 있어 중요한 기준을 제공합니다.",
                Images = new List<CardImage> { new CardImage(  "https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return standardCard;
        }
        public static HeroCard GetImprovementCard()
        {
            var improvementCard = new HeroCard
            {
                Title = "개선관리에 대해서 알아봅니다.",
                Subtitle = "어떤 것이 궁금하신가요?",
                Text = "개선관리는 QMS에서 OOO한 메뉴입니다." +
                       "제품 개선의 주요한 사항을 정리합니다.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return improvementCard;
        }
        public static HeroCard GetQcostCard()
        {
            var qcostCard = new HeroCard
            {
                Title = "QCOST에 대해서 알아봅니다.",
                Subtitle = "어떤 것이 궁금하신가요?",
                Text = "QCOST은 QMS에서 OOO한 메뉴입니다." +
                       "가장 편한 비용 관리의 기회를 제공합니다.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return qcostCard;
        }

        public static HeroCard GetThumbnailCard()
        {
            var thumbnailCard = new HeroCard
            {
                Title = "BotFramework Thumbnail Card",
                Subtitle = "Microsoft Bot Framework",
                Text = "Build and connect intelligent bots to interact with your users naturally wherever they are," +
                       " from text/sms to Skype, Slack, Office 365 mail and other popular services.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return thumbnailCard;
        }

        public static AnimationCard GetAnimationCard()
        {
            var animationCard = new AnimationCard
            {
                Title = "Microsoft Bot Framework",
                Subtitle = "Animation Card",
                Image = new ThumbnailUrl
                {
                    Url = "https://docs.microsoft.com/en-us/bot-framework/media/how-it-works/architecture-resize.png",
                },
                Media = new List<MediaUrl>
                {
                    new MediaUrl()
                    {
                        Url = "http://i.giphy.com/Ki55RUbOV5njy.gif",
                    },
                },
            };

            return animationCard;
        }
    }
}
