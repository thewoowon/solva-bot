using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using SolvaBot.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace SolvaBot
{
    public class MainDialog : ComponentDialog
    {
        protected readonly ILogger _logger;
        SOLVABOTContext _context;
        private string categoryCode = string.Empty;
        private string menuCode = string.Empty;
        private string detailCode = string.Empty;
        private string _companyCode = "AAAAA1";

        public SOLVABOTContext Context
        {
            get { return _context; }
        }

        public MainDialog(ILogger<MainDialog> logger)
            : base(nameof(MainDialog))
        {
            _logger = logger;

            AddDialog(new ChoicePrompt(nameof(ChoicePrompt)));
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                ShowMainCardAsync,
                ShowFirstWaterfallCardAsync,
                ShowSecondWaterfallCardAsync,
                ShowDetailAndSaveMenuAsync,
            }));

            InitialDialogId = nameof(WaterfallDialog);
            _context = new SOLVABOTContext();
        }

        private async Task<DialogTurnResult> ShowMainCardAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            _logger.LogInformation("MainDialog.ChoiceCardStepAsync");

            var options = new PromptOptions()
            {  
                Prompt = MessageFactory.Text("쉽고 빠른 시작을 위해서 메뉴를 선택해 주세요."),
                RetryPrompt = MessageFactory.Text("죄송하지만 해당 서비스가 존재하지 않습니다. 카드를 선택하시거나 단어를 입력해주세요."),
                Choices = GetMainChoice(),
            };

            return await stepContext.PromptAsync(nameof(ChoicePrompt), options, cancellationToken);
        }

        private async Task<DialogTurnResult> ShowFirstWaterfallCardAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            _logger.LogInformation("MainDialog.ChoiceCardStepAsync");
            categoryCode = string.Empty;
            menuCode = string.Empty;
            detailCode = string.Empty;

            var attachments = new List<Attachment>();

            var reply = MessageFactory.Attachment(attachments);

            switch (((FoundChoice)stepContext.Result).Value)
            {
                case "카테고리선택":
                    var options1 = new PromptOptions()
                    {
                        Prompt = MessageFactory.Text("쉽고 빠른 시작을 위해서 메뉴를 선택해 주세요."),
                        RetryPrompt = MessageFactory.Text("죄송하지만 해당 서비스가 존재하지 않습니다. 카드를 선택하시거나 단어를 입력해주세요."),
                        Choices = GetChoices(),
                        Style = ListStyle.HeroCard,
                    };
                    return await stepContext.PromptAsync(nameof(ChoicePrompt), options1, cancellationToken);
                case "담당자채팅":
                    var options2 = new PromptOptions()
                    {
                        Prompt = MessageFactory.Text("쉽고 빠른 시작을 위해서 메뉴를 선택해 주세요."),
                        RetryPrompt = MessageFactory.Text("죄송하지만 해당 서비스가 존재하지 않습니다. 카드를 선택하시거나 단어를 입력해주세요."),
                        Choices = GetChoices(),
                        Style = ListStyle.HeroCard,
                    };
                    return await stepContext.PromptAsync(nameof(ChoicePrompt), options2, cancellationToken);
                case "Q&A":
                    var options3 = new PromptOptions()
                    {
                        Prompt = MessageFactory.Text("쉽고 빠른 시작을 위해서 메뉴를 선택해 주세요."),
                        RetryPrompt = MessageFactory.Text("죄송하지만 해당 서비스가 존재하지 않습니다. 카드를 선택하시거나 단어를 입력해주세요."),
                        Choices = GetChoices(),
                        Style = ListStyle.HeroCard,
                    };
                    return await stepContext.PromptAsync(nameof(ChoicePrompt), options3, cancellationToken);
                case "홈페이지":
                    var options4 = new PromptOptions()
                    {
                        Prompt = MessageFactory.Text("쉽고 빠른 시작을 위해서 메뉴를 선택해 주세요."),
                        RetryPrompt = MessageFactory.Text("죄송하지만 해당 서비스가 존재하지 않습니다. 카드를 선택하시거나 단어를 입력해주세요."),
                        Choices = GetChoices(),
                        Style = ListStyle.HeroCard,
                    };
                    return await stepContext.PromptAsync(nameof(ChoicePrompt), options4, cancellationToken);
                default:
                    var options5 = new PromptOptions()
                    {
                        Prompt = MessageFactory.Text("쉽고 빠른 시작을 위해서 메뉴를 선택해 주세요."),
                        RetryPrompt = MessageFactory.Text("죄송하지만 해당 서비스가 존재하지 않습니다. 카드를 선택하시거나 단어를 입력해주세요."),
                        Choices = GetChoices(),
                        Style = ListStyle.HeroCard,
                    };
                    return await stepContext.PromptAsync(nameof(ChoicePrompt), options5, cancellationToken);

            }
        }
        private async Task<DialogTurnResult> ChoiceCommonCardStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            _logger.LogInformation("MainDialog.ChoiceCommonCardStepAsync");

            var options = new PromptOptions()
            {
                Prompt = MessageFactory.Text("해당 메뉴의 선택사항입니다."),
                RetryPrompt = MessageFactory.Text("죄송하지만 해당 서비스가 존재하지 않습니다. 카드를 선택하시거나 단어를 입력해주세요."),
                Choices = GetCommonChoices(),
                Style = ListStyle.HeroCard,
            };

            return await stepContext.PromptAsync(nameof(ChoicePrompt), options, cancellationToken);
        }

        private async Task<DialogTurnResult> ShowSecondWaterfallCardAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            FoundChoice foundChoice = (FoundChoice)stepContext.Result;

            _logger.LogInformation("MainDialog.ShowCardStepAsync");

            TblComCategory[] category;

            category = (from e in Context.TblComCategory
                        where e.CompanyCode == _companyCode
                        select e).ToArray();

            categoryCode = category[foundChoice.Index].Code;
            var attachments = new List<Attachment>();
            var reply = MessageFactory.Attachment(attachments);

            TblComMenu[] menu;

            menu = (from e in Context.TblComMenu
                        where e.CategoryCode == categoryCode
                    select e).ToArray();

            var cardOptions = new List<Choice>();

            foreach (var c in menu)
            {
                cardOptions.Add(new Choice() { Value = c.Title, Synonyms = new List<string>() { c.Code } });
            };

            var options = new PromptOptions()
            {
                Prompt = MessageFactory.Text("해당 메뉴의 선택사항입니다."),
                RetryPrompt = MessageFactory.Text("죄송하지만 해당 서비스가 존재하지 않습니다. 카드를 선택하시거나 단어를 입력해주세요."),
                Choices = cardOptions,
                Style = ListStyle.HeroCard,
            };

            return await stepContext.PromptAsync(nameof(ChoicePrompt), options, cancellationToken);
        }

        private async Task<DialogTurnResult> ShowDetailAndSaveMenuAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            FoundChoice foundChoice = (FoundChoice)stepContext.Result;

            _logger.LogInformation("MainDialog.ShowCommonCardStepAsync");

            TblComMenu[] menu;

            menu = (from e in Context.TblComMenu
                    where e.CategoryCode == categoryCode
                    select e).ToArray();

            menuCode = menu[foundChoice.Index].Code;
            var attachments = new List<Attachment>();
            var reply = MessageFactory.Attachment(attachments);

            TblComMenuDetail[] detail;

            detail = (from e in Context.TblComMenuDetail
                      where e.MenuCode == menuCode
                      select e).ToArray();


            TblComAddfiles[] detailImage = new TblComAddfiles[1];
            TblComAddfiles[] detailDocu = new TblComAddfiles[1];


            if (detail != null && detail.Length > 0)
            {
                detailImage = (from e in Context.TblComAddfiles
                               where e.Pcode == detail[0].Code && e.Role == 1
                               select e).ToArray();

                detailDocu = (from e in Context.TblComAddfiles
                              where e.Pcode == detail[0].Code && e.Role == 2
                              select e).ToArray();
            }

            var cardOptions = new List<Choice>();

            HeroCard heroCard = new HeroCard();
            heroCard = Cards.GetHeroCard();

            foreach (var c in detail)
            {
                heroCard.Title = c.Title;
                heroCard.Text = c.Content;
                heroCard.Subtitle = c.SubTitle;

                if(detailImage.Length > 0)
                {
                    heroCard.Images = new List<CardImage> { new CardImage("https://solvabotmanager.solva.co.kr/" + _companyCode + "/Images/" + detailImage[0].Fn) };
                }
                else
                {
                    heroCard.Images = new List<CardImage> { new CardImage("https://solvabotmanager.solva.co.kr/BlackGround.png") };
                }

                if (detailDocu.Length > 0)
                {
                    heroCard.Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "파일 다운로드", value: "https://solvabotmanager.solva.co.kr/" + _companyCode + "/Docus/" + detailDocu[0].Fn) };
                }
                else
                {
                    heroCard.Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "파일 다운로드", value: "https://solvabotmanager.solva.co.kr/SolvaReference.png") };
                }
            };

            reply.Attachments.Add(heroCard.ToAttachment());

            await stepContext.Context.SendActivityAsync(reply, cancellationToken);
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("다른 선택을 원하십니까?"), cancellationToken);

            return await stepContext.EndDialogAsync();
        }

        private IList<Choice> GetMainChoice()
        {

            var cardOptions = new List<Choice>();

            cardOptions.Add(new Choice() { Value = "카테고리선택", Synonyms = new List<string>() { "카테고리", "카테", "카테고리선택" } });
            cardOptions.Add(new Choice() { Value = "담당자채팅", Synonyms = new List<string>() { "담당자채팅", "담당", "담당자", "채팅" } });
            cardOptions.Add(new Choice() { Value = "Q&A", Synonyms = new List<string>() { "Q&A","QA","qa","qna" } });
            cardOptions.Add(new Choice() { Value = "홈페이지", Synonyms = new List<string>() { "홈페이지", "홈" } });

            return cardOptions;
        }

        private IList<Choice> GetChoices()
        {
            TblComCategory[] category;

            category = (from e in Context.TblComCategory
                        where e.CompanyCode == _companyCode
                        select e).ToArray();

            var cardOptions = new List<Choice>();

            foreach (var c in category)
            {
                cardOptions.Add(new Choice() { Value = c.Title, Synonyms = new List<string>() { c.Code } });
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
