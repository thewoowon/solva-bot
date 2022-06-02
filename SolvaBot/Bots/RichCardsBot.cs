// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;

namespace SolvaBot
{
    // RichCardsBot prompts a user to select a Rich Card and then returns the card
    // that matches the user's selection.
    public class RichCardsBot : DialogBot<MainDialog>
    {
        public RichCardsBot(ConversationState conversationState, UserState userState, MainDialog dialog, ILogger<DialogBot<MainDialog>> logger)
            : base(conversationState, userState, dialog, logger)
        {
        }
 
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    var attachments = new List<Attachment>();
                    var reply = MessageFactory.Text("Hello");

                    HeroCard heroCard = new HeroCard();
                    heroCard = Cards.GetHeroCard();
                    
                    heroCard.Title = "솔바테크놀러지 QMS";
                    heroCard.Subtitle = "새로운 서비스를 경험하세요.";
                    heroCard.Text = "홈페이지에서 더 많은 제품을 만나 보실 수 있습니다.";
                    heroCard.Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") };
                    heroCard.Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "HOME", value: "http://www.solva.co.kr/") };

                    Activity[] activity = new Activity[3];
                    activity[0] = MessageFactory.Text("안녕하세요.솔바테크놀러지 챗봇 도우미입니다.");
                    activity[1] = MessageFactory.Text("솔바 테크놀러지의 QMS를 이용해주셔서 감사합니다.\n" +
                                       " 보다 더 나은 서비스를 제공하기 위해 항상 노력하겠습니다.");
                    activity[2] = MessageFactory.Text("");
                    activity[2].Attachments.Add(heroCard.ToAttachment());

                    //await turnContext.SendActivityAsync(reply,cancellationToken);
                    
                    await turnContext.SendActivitiesAsync(activity, cancellationToken);
                }
            }
        }

        private IList<Choice> GetCommonChoices()
        {
            var cardOptions = new List<Choice>()
            {
                new Choice() { Value = "카테고리 선택", Synonyms = new List<string>() { "category" } },
                new Choice() { Value = "담당자 채팅", Synonyms = new List<string>() { "chat" } },
                new Choice() { Value = "Q&A", Synonyms = new List<string>() { "qna" } },
            };
            return cardOptions;
        }
    }
}
