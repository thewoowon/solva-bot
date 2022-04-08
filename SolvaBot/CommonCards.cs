// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Web;

namespace SolvaBot
{
    public static class CommonCards
    {
        public static HeroCard GetApprovalCard()
        {
            var approvalCard = new HeroCard
            {
                Title = "결재 과정에 대해서 알아봅니다.",
                Subtitle = "결재 과정의 주체를 기억하세요.",
                Text = "결재는 가장 중요한 과정 중 하나입니다." +
                       "확실한 결재선을 입력하는 것이 바람직합니다." +
                       "반려, 검토, 승인, 개정 등이 결재선에 노출됩니다.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return approvalCard;
        }
        public static HeroCard GetRegisterCard()
        {
            var registerCard = new HeroCard
            {
                Title = "등록 과정에 대해서 알아봅니다.",
                Subtitle = "등록 과정은 다소 복잡할 수 있습니다.",
                Text = "필수 적인 요소들은 애스테릭 기호로 강조됩니다." +
                       "아래의 템플릿들을 참조하세요.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "템플릿 보기", value: "https://docs.microsoft.com/bot-framework") },
            };

            return registerCard;
        }
        public static HeroCard GetReviseCard()
        {
            var reviseCard = new HeroCard
            {
                Title = "개정 과정에 대해서 알아봅니다.",
                Subtitle = "수정과는 다른 의미입니다.",
                Text = "개정 후 다시 결재선이 시작합니다." +
                       "개정 기록은 모두 남아있습니다.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return reviseCard;
        }
        public static HeroCard GetManagerCard()
        {
            var managerCard = new HeroCard
            {
                Title = "관련 담당자의 정보를 확인하세요.",
                Subtitle = "기술지원 및 영업시간은 오전 9시부터 오후 6시까지입니다.",
                Text = "담당자 부서 : 영남지사" +
                       "담당자 이름 : 송 강" +
                       "담당자 직급 : 대리" +
                       "담당자 내선번호 : 051-707-8888"
                       ,
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
            };

            return managerCard;
        }
        public static HeroCard GetChatCard()
        {
            var chatCard = new HeroCard
            {
                Title = "담당자와 채팅을 통해 연결합니다.",
                Subtitle = "담당자의 현재 접속상태를 먼저 확인합니다.",
                Text = "담당자 이름 : 유재석" +
                       "아래 버튼을 누르면 채팅이 연결됩니다. " +
                       "담당자 상태에 따라 다소 시간이 걸릴 수 있습니다.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "채팅연결하기", value: "https://docs.microsoft.com/bot-framework") },
            };

            return chatCard;
        }
        public static HeroCard GetMailCard()
        {
            var mailCard = new HeroCard
            {
                Title = "담당자에게 메일을 보냅니다.",
                Subtitle = "담당자의 확인을 기다려주세요.",
                Text = "아래의 버튼을 누르면 메일폼이 열립니다."+
                        "간단한 내용을 작성해 주세요.",
                Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "메일폼 열기", value: "https://docs.microsoft.com/bot-framework") },
            };

            return mailCard;
        }
        
    }
}
