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
    public class MainDialog : ComponentDialog
    {
        protected readonly ILogger _logger;

        public MainDialog(ILogger<MainDialog> logger)
            : base(nameof(MainDialog))
        {
            _logger = logger;

            // Define the main dialog and its related components.
            AddDialog(new ChoicePrompt(nameof(ChoicePrompt)));
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                ChoiceCardStepAsync,
                ShowCardStepAsync,
                //ChoiceCommonCardStepAsync,
                ShowCommonCardStepAsync,
            }));

            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);
        }

        // 1. Prompts the user if the user is not in the middle of a dialog.
        // 2. Re-prompts the user when an invalid input is received.
        private async Task<DialogTurnResult> ChoiceCardStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            _logger.LogInformation("MainDialog.ChoiceCardStepAsync");

            // Create the PromptOptions which contain the prompt and re-prompt messages.
            // PromptOptions also contains the list of choices available to the user.
            var options = new PromptOptions()
            {
                Prompt = MessageFactory.Text("쉽고 빠른 시작을 위해서 메뉴를 선택해 주세요."),
                RetryPrompt = MessageFactory.Text("죄송하지만 해당 서비스가 존재하지 않습니다. 카드를 선택하시거나 단어를 입력해주세요."),
                Choices = GetChoices(),
                Style = ListStyle.HeroCard,
            };

            // Prompt the user with the configured PromptOptions.
            return await stepContext.PromptAsync(nameof(ChoicePrompt), options, cancellationToken);
        }
        private async Task<DialogTurnResult> ChoiceCommonCardStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            _logger.LogInformation("MainDialog.ChoiceCommonCardStepAsync");

            // Create the PromptOptions which contain the prompt and re-prompt messages.
            // PromptOptions also contains the list of choices available to the user.
            var options = new PromptOptions()
            {
                Prompt = MessageFactory.Text("해당 메뉴의 선택사항입니다."),
                RetryPrompt = MessageFactory.Text("죄송하지만 해당 서비스가 존재하지 않습니다. 카드를 선택하시거나 단어를 입력해주세요."),
                Choices = GetCommonChoices(),
                Style = ListStyle.HeroCard,
            };

            // Prompt the user with the configured PromptOptions.
            return await stepContext.PromptAsync(nameof(ChoicePrompt), options, cancellationToken);
        }

        // Send a Rich Card response to the user based on their choice.
        // This method is only called when a valid prompt response is parsed from the user's response to the ChoicePrompt.
        private async Task<DialogTurnResult> ShowCardStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            _logger.LogInformation("MainDialog.ShowCardStepAsync");
            
            // Cards are sent as Attachments in the Bot Framework.
            // So we need to create a list of attachments for the reply activity.
            var attachments = new List<Attachment>();
            
            // Reply to the activity we received with an activity.
            var reply = MessageFactory.Attachment(attachments);
            
            // Decide which type of card(s) we are going to show the user
            switch (((FoundChoice)stepContext.Result).Value)
            {

                case "품질분석":
                    // Display an Adaptive Card
                    reply.Attachments.Add(Cards.GetQualityCard().ToAttachment());
                    break;
                case "고객불만":
                    // Display an AnimationCard.
                    reply.Attachments.Add(Cards.GetComplaintCard().ToAttachment());
                    break;
                case "검사관리":
                    // Display an AudioCard
                    reply.Attachments.Add(Cards.GetInspectionCard().ToAttachment());
                    break;
                case "부적합관리":
                    // Display a HeroCard.
                    reply.Attachments.Add(Cards.GetNonconformingCard().ToAttachment());
                    break;
                case "심사관리":
                    // Display an OAuthCard
                    reply.Attachments.Add(Cards.GetJudgeCard().ToAttachment());
                    break;
                case "변경관리":
                    // Display a ReceiptCard.
                    reply.Attachments.Add(Cards.GetChangeCard().ToAttachment());
                    break;
                case "시험의뢰":
                    // Display a SignInCard.
                    reply.Attachments.Add(Cards.GetTestCard().ToAttachment());
                    break;
                case "표준관리":
                    // Display a ThumbnailCard.
                    reply.Attachments.Add(Cards.GetStandardCard().ToAttachment());
                    break;
                case "개선과제":
                    // Display a VideoCard
                    reply.Attachments.Add(Cards.GetImprovementCard().ToAttachment());
                    break;
                case "QCOST":
                    reply.Attachments.Add(Cards.GetQcostCard().ToAttachment());
                    break;
            }

            // 여기서 카드를 보여주는 곳입니다.
            await stepContext.Context.SendActivityAsync(reply, cancellationToken);
            // 공통적인 사항에 대한 히어로 카드를 제시하는 곳


            var options = new PromptOptions()
            {
                Prompt = MessageFactory.Text("해당 메뉴의 선택사항입니다."),
                RetryPrompt = MessageFactory.Text("죄송하지만 해당 서비스가 존재하지 않습니다. 카드를 선택하시거나 단어를 입력해주세요."),
                Choices = GetCommonChoices(),
                Style = ListStyle.HeroCard,
            };

            // Prompt the user with the configured PromptOptions.
            return await stepContext.PromptAsync(nameof(ChoicePrompt), options, cancellationToken);
        }

        private async Task<DialogTurnResult> ShowCommonCardStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            _logger.LogInformation("MainDialog.ShowCommonCardStepAsync");

            // Cards are sent as Attachments in the Bot Framework.
            // So we need to create a list of attachments for the reply activity.
            var attachments = new List<Attachment>();

            // Reply to the activity we received with an activity.
            var reply = MessageFactory.Attachment(attachments);

            // Decide which type of card(s) we are going to show the user
            switch (((FoundChoice)stepContext.Result).Value)
            {

                case "결재 과정 알아보기":
                    // Display an Adaptive Card
                    reply.Attachments.Add(CommonCards.GetApprovalCard().ToAttachment());
                    break;
                case "등록 과정 알아보기":
                    // Display an AnimationCard.
                    reply.Attachments.Add(CommonCards.GetRegisterCard().ToAttachment());
                    break;
                case "개정 등록 알아보기":
                    // Display an AudioCard
                    reply.Attachments.Add(CommonCards.GetReviseCard().ToAttachment());
                    break;
                case "담당자 알아보기":
                    // Display a HeroCard.
                    reply.Attachments.Add(CommonCards.GetManagerCard().ToAttachment());
                    break;
                case "담당자 채팅연결":
                    // Display an OAuthCard
                    reply.Attachments.Add(CommonCards.GetChatCard().ToAttachment());
                    break;
                case "오류 메일 보내기":
                    // Display an OAuthCard
                    reply.Attachments.Add(CommonCards.GetMailCard().ToAttachment());
                    break;

            }

            // 여기서 카드를 보여주는 곳입니다.
            await stepContext.Context.SendActivityAsync(reply, cancellationToken);

            // Give the user instructions about what to do next
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("다른 선택을 원하십니까?"), cancellationToken);

            return await stepContext.EndDialogAsync();
        }

        private IList<Choice> GetChoices()
        {
            var cardOptions = new List<Choice>()
            {
                new Choice() { Value = "품질분석", Synonyms = new List<string>() { "quality" } },
                new Choice() { Value = "고객불만", Synonyms = new List<string>() { "complaint" } },
                new Choice() { Value = "검사관리", Synonyms = new List<string>() { "inspection" } },
                new Choice() { Value = "부적합관리", Synonyms = new List<string>() { "nonconforming" } },
                new Choice() { Value = "심사관리", Synonyms = new List<string>() { "judge" } },
                new Choice() { Value = "변경관리", Synonyms = new List<string>() { "change" } },
                new Choice() { Value = "시험의뢰", Synonyms = new List<string>() { "test" } },
                new Choice() { Value = "표준관리", Synonyms = new List<string>() { "standard" } },
                new Choice() { Value = "개선과제", Synonyms = new List<string>() { "improvement" } },
                new Choice() { Value = "QCOST", Synonyms = new List<string>() { "qcost" } },
            };

            return cardOptions;
        }

        private IList<Choice> GetCommonChoices()
        {
            var cardOptions = new List<Choice>()
            {
                new Choice() { Value = "결재 과정 알아보기", Synonyms = new List<string>() { "approval" } },
                new Choice() { Value = "등록 과정 알아보기", Synonyms = new List<string>() { "Register" } },
                new Choice() { Value = "개정 등록 알아보기", Synonyms = new List<string>() { "revise" } },
                new Choice() { Value = "담당자 알아보기", Synonyms = new List<string>() { "manager" } },
                new Choice() { Value = "담당자 채팅연결", Synonyms = new List<string>() { "chat" } },
                new Choice() { Value = "오류 메일 보내기", Synonyms = new List<string>() { "mail" } },
            };

            return cardOptions;
        }
    }
}
