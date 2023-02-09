using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAnalitics.Application.Models
{
    public class ApiSmevModel
    {
        public List<string> GetAllMethods()
        {
            List<string> allmethods = new()
        {
        //v3
            "epbs_np", "epbs_fp", "epbs_fp_events", "epbs_np_participants", "epbs_fp_participants", "epbs_fp_fin_sources_all",
            "epbs_rp", "epbs_rp_participants", "epbs_rp_events", "epbs_document_types", "epbs_program", "epbs_bp_okei", "epbs_organization_roiv",
            "epbs_rf_subject", "mu_np_tasks", "mu_np_purposes", "mu_np_fin_sources", "mu_fp_tasks", "mu_fp_results", "mu_fp_purposes", "mu_fp_fin_sources", "mu_fp_check_points",
            "mu_fp_fin_sources_month", "mu_natgoal", "fp_results_other_project_new", "MuFpFinSourcesAll", "MuRpFinSourcesAll", "mu_rp_tasks", "mu_rp_purposes", "mu_rp_results",
            "rp_results_other_project", "mu_rp_check_points", "mu_rp_fin_sources", "mu_rp_fin_sources_month",

            "checkpointsprivate", "resultsprivate", "projectfinprovisionoperativeprivate", "projectfinprovisiononreportprivate", "resultsfinprovisionreportprivate", "stateprivate",
            "monitoringfbfpprivate", "ziprivate", "agreementresultsprivate", "agreementpurposeprivate", "monitoringFpprivate", "monitoringRpprivate", "monitoringfbbaprivate",
            "gos_program_fpprivate", "gos_program_rpprivate", "eventsprivate", "parameterprivate", "agreementprivate", "results_subprivate", "heads_bkprivate", "evaluationassis_npprivate",
            "evaluationassis_fpprivate", "mu_goalprivate", "mu_datasourceisprivate", "mu_socialsignificanceresultsprivate", "federal_districtprivate", "OMCheckpointsprivate", "OMPurposeprivate", "OMTasksprivate", "OMResultsprivate",
            "OMRisksprivate", "npa_kindprivate", "mu_key_risksprivate", "mu_npfppurposecriteriaprivate", "mu_resultsprivate", "mu_checkpointsprivate", "epbs_program_rpprivate",
            "fbexecutionmonthlyprivate", "indicator_gosprograms_fpprivate", "epbs_subprogram_fpprivate",
        //v2
            "checkpointsprivate", "projectfinprovisionoperativeprivate", "projectfinprovisiononreportprivate", "npfppurposecriteriaprivate", "resultsprivate", "resultsfinprovisionreportprivate", "stateprivate", "resultsfinprovisionoperativeprivate",
            "monitoringfbfpprivate", "npamountsprivate", "fpamountsprivate", "rpamountsprivate", "gos_program_fpprivate",
        //v1
            "investment_projects","epbs_np", "epbs_np_tasks", "epbs_np_fin_sources", "epbs_np_purposes", "epbs_fp", "epbs_fp_tasks", "epbs_fp_results", "epbs_fp_check_points",
            "epbs_fp_events", "epbs_np_participants", "epbs_fp_participants", "epbs_fp_fin_sources", "epbs_fp_fin_sources_all", "epbs_fp_purposes", "epbs_rp", "epbs_rp_results",
            "epbs_rp_purposes", "epbs_rp_participants", "epbs_rp_check_points", "epbs_rp_events", "epbs_rp_fin_sources", "epbs_rp_all", "epbs_document_types", "epbs_program",
            "epbs_bp_okei", "epbs_organization_roiv", "epbs_rf_subject", "mu_np_tasks", "mu_np_purposes", "mu_np_fin_sources", "mu_fp_tasks", "mu_fp_results", "mu_fp_purposes",
            "mu_fp_fin_sources", "mu_fp_check_points", "mu_fp_fin_sources_month", "mu_natgoal", "fp_results_other_project_new", "MuFpFinSourcesAll", "MuRpFinSourcesAll",
            "mu_rp_tasks", "mu_rp_purposes", "mu_rp_results", "rp_results_other_project", "mu_rp_check_points", "mu_rp_fin_sources", "mu_rp_fin_sources_month",
            "register_projects_questions", "register_questions", "report_register_projects_questions", "changerequests_register_projects_questions",

            "checkpointsprivate", "projectfinprovisionoperativeprivate", "projectfinprovisiononreportprivate", "npfppurposecriteriaprivate", "resultsprivate",
            "resultsfinprovisionreportprivate", "resultsfinprovisionreport_rpprivate", "stateprivate", "resultsfinprovisionoperativeprivate", "monitoringfbfpprivate",
            "npamountsprivate", "fpamountsprivateprivate", "rpamountsprivateprivate", "ziprivate", "zi_rpprivate", "agreementresultsprivate", "agreementpurposeprivate",
            "direction_costsprivate", "type_resultsprivate", "type_checkpointsprivate", "monitoringFpprivate", "monitoringRpprivate", "monitoringfbbaprivate", "gos_program_fpprivate",
            "gos_program_rpprivate", "key_risksprivate", "eventsprivate", "key_parameterprivate", "agreementprivate", "results_subprivate", "heads_bkprivate",
            "evaluationassis_npprivate", "evaluationassis_fpprivate", "mu_goalprivate", "mu_datasourceisprivate", "mu_socialsignificanceresultsprivate", "federal_districtprivate",
            "OMCheckpointsprivate", "OMPurposeprivate", "OMTasksprivate", "OMResultsprivate", "OMRisksprivate", "npa_kindprivate", "mu_key_risksprivate",
            "mu_npfppurposecriteriaprivate", "mu_resultsprivate", "mu_checkpointsprivate", "mu_checkpoints_rpprivate", "epbs_program_rpprivate", "fbexecutionmonthlyprivate",
            "indicator_gosprograms_fpprivate", "epbs_subprogram_fpprivate", "monitoring_redistribution_reportprivate"
        };
            return allmethods;
        }

        public List<string> GetAllDocumentTypes()
        {
            List<string> list = new()
                {
                    "«00» - Перечень документов",
                    "«6» -  Расчет базовых БА (базовых бюджетных ассигнований - подписываемая часть)",
                    "«7» -  Расчет базовых БА (базовых бюджетных ассигнований - не подписываемая часть)",                        
                    "«8» -  Расчет базовых БА с Доп. БА (подписываемая часть)",
                    "«9» -  Расчет базовых БА с Доп. БА (не подписываемая часть)",                      
                    "«10» - Паспорт проекта (подписываемая часть)",
                    "«11» - Паспорт проекта (не подписываемая часть)",
                    "«14» - Комплексный тип документа паспорт инфраструктурного проекта",
                    "«20» - Рабочий план",
                    "«21» - Запрос на изменение рабочего плана",
                    "«30» - Отчет о ходе реализации национального проекта",
                    "«31» - Отчет о ходе реализации федерального (регионального) проекта",
                    "«32» - Отчет о ходе реализации паспортов проектов и вопросов", 
                    "«33» - Исполнения НП,ФП,РП",
                    "«34» - Аналитический отчет",                        
                    "«40» - Запрос на изменение",
                    "«41» - Не примененный запрос на изменение",
                    "«42» - Запрос на изменение паспортов проектов и вопросов",                           
                    "«50» - Документ паспортов проектов и вопросов",
                    "«60» - Документ паспорт инвестиционного проекта",
                    "«70» - справочник «Типовые результаты и типовые КТ»",
                    "«110» - Перечень паспортов государственных программ",
                    "«120» - Паспорт государственной программы",
                    "«121» - Редакция паспорта государственной программы",
                    "«130» - Перечень паспортов ведомственных проектов",
                    "«140» - Паспорт ведомственного проекта",
                    "«141» - Редакция паспорта ведомственного проекта",
                    "«150» - Перечень паспортов комплексов процессных мероприятий",
                    "«160» - Паспорт комплекса процессных мероприятий",
                    "«161» - Редакция паспорта комплекса процессных мероприятий",
                    "«170» - Маркировка элементов государственной программы",
                    "«180» - Маркировка элементов ведомственного проекта",
                    "«190» - Маркировка элементов комплекса процессных мероприятий",
                    "«200» - Единый запрос на изменение",
                    "«201» - Предложение на изменение ГП",
                    "«202» - Предложение на изменение ВП",
                    "«203» - Предложение на изменение КПМ",
                    "«205» - Дополнение к Единому запросу на изменение",
                    "«210» - Перечень отчетов о ходе реализации ведомственного проекта",
                    "«220» - Отчет о ходе реализации ведомственного проекта",
                    "«221» - Сведения об исполнение ведомственного проекта",
                    "«230» - Перечень отчетов о ходе реализации государственной программы",
                    "«240» - Отчет о ходе реализации ГП",
                    "«241» - Сведения об исполнении государственной программы",
                    "«250» - Перечень отчетов о ходе реализации комплекса процессных мероприятий",
                    "«260» - Отчет о ходе реализации КПМ",
                    "«261» - Сведения об исполнение комплекса процессных мероприятий",
                    "«270» - Единый аналитический план"
                };
            
            /*
            var list = new Dictionary<string, string>()
            {
                {"00" , "Перечень документов"},
            {"6" ,  "Расчет базовых БА (базовых бюджетных ассигнований - подписываемая часть)"},
            {"7" ,  "Расчет базовых БА (базовых бюджетных ассигнований - не подписываемая часть)"},                        
            {"8" ,  "Расчет базовых БА с Доп. БА (подписываемая часть)"},
            {"9" ,  "Расчет базовых БА с Доп. БА (не подписываемая часть)"},                      
            {"10" , "Паспорт проекта (подписываемая часть)"},
            {"11" , "Паспорт проекта (не подписываемая часть)"},
            {"14" , "Комплексный тип документа паспорт инфраструктурного проекта"},
            {"20" , "Рабочий план"},
            {"21" , "Запрос на изменение рабочего плана"},
            {"30" , "Отчет о ходе реализации национального проекта"},
            {"31" , "Отчет о ходе реализации федерального (регионального) проекта"},
            {"32" , "Отчет о ходе реализации паспортов проектов и вопросов"}, 
            {"33" , "Исполнения НП,ФП,РП"},
            {"34" , "Аналитический отчет"},                        
            {   "40" , "Запрос на изменение"},
            {   "41" , "Не примененный запрос на изменение"},
            {   "42" , "Запрос на изменение паспортов проектов и вопросов"},                           
            {   "50" , "Документ паспортов проектов и вопросов"},
            {   "60" , "Документ паспорт инвестиционного проекта"},
            {   "70" , "справочник Типовые результаты и типовые КТ"},
            {   "110" , "Перечень паспортов государственных программ"},
            {   "120" , "Паспорт государственной программы"},
            {   "121" , "Редакция паспорта государственной программы"},
            {   "130" , "Перечень паспортов ведомственных проектов"},
            {   "140" , "Паспорт ведомственного проекта"},
            {   "141" , "Редакция паспорта ведомственного проекта"},
            {   "150" , "Перечень паспортов комплексов процессных мероприятий"},
            {   "160" , "Паспорт комплекса процессных мероприятий"},
            {   "161" , "Редакция паспорта комплекса процессных мероприятий"},
            {   "170" , "Маркировка элементов государственной программы"},
            {   "180" , "Маркировка элементов ведомственного проекта"},
            {   "190" , "Маркировка элементов комплекса процессных мероприятий"},
             {   "200" , "Единый запрос на изменение"},
              {  "201" , "Предложение на изменение ГП"},
               { "202" , "Предложение на изменение ВП"},
               {"203" , "Предложение на изменение КПМ"},
               {"205" , "Дополнение к Единому запросу на изменение"},
               {"210" , "Перечень отчетов о ходе реализации ведомственного проекта"},
               {"220" , "Отчет о ходе реализации ведомственного проекта"},
               {"221" , "Сведения об исполнение ведомственного проекта"},
               {"230" , "Перечень отчетов о ходе реализации государственной программы"},
               {"240" , "Отчет о ходе реализации ГП"},
               {"241" , "Сведения об исполнении государственной программы"},
               {"250", "Перечень отчетов о ходе реализации комплекса процессных мероприятий"},
               {"260", "Отчет о ходе реализации КПМ"},
                {"261", "Сведения об исполнение комплекса процессных мероприятий"},
                {"270", "Единый аналитический план"}
            };
            */
            
            
                return list;
        }
        
        public List<string> GetAllDocumentVersions()
        {
            List<string> list = new()
                {
                    "Option 0",
                    "Option 1",
                    "Option 2"                        
                };
                return list;
        }
        
        public List<string> GetAllDocumentNumbers()
        {
            List<string> list = new()
            {
                "Option 0",
                "Option 1",
                "Option 2"                        
            };
            return list;
        }
        
        public List<string> GetAllTypeTypes()
        {
            List<string> list = new()
            {
                "Option 0",
                "Option 1",
                "Option 2"                        
            };
            return list;
        }
        
        public List<string> GetAllSubjectCodes()
        {
            List<string> list = new()
            {
                "Option 0",
                "Option 1",
                "Option 2"                        
            };
            return list;
        }
        
        public List<string> GetAllTimes()
        {
            List<string> list = new()
            {
                "Option 0",
                "Option 1",
                "Option 2"                        
            };
            return list;
        }
        
        public List<string> GetAllBase64Formats()
        {
            List<string> list = new()
            {
                "Option 0",
                "Option 1",
                "Option 2"                        
            };
            return list;
        }
    }

}