﻿Ext.define('Документы.БюджетнаяОперация.ФормаДокумента',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:660px;height:426px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Бюджетная операция',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'label',
			name: 'Надпись1',
			text: 'Номер:',
			style: 'position:absolute;left:8px;top:33px;width:92px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Номер',
			width: 80,
			height: 19,
			style: 'position:absolute;left:102px;top:33px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись23',
			text: 'от:',
			style: 'position:absolute;left:184px;top:33px;width:16px;height:19px;text-align:center;',
		},
		{
			xtype: 'datefield',
			hideLabel: true,
			disabled: false,
			value: 0,
			format: 'd.m.Y',
			name: 'Дата',
			width: 120,
			height: 19,
			style: 'position:absolute;left:202px;top:33px;width:120px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись24',
			text: 'Сценарий:',
			style: 'position:absolute;left:8px;top:57px;width:92px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			trigger3Cls: 'x-form-search-trigger',
			name: 'Сценарий',
			width: 220,
			height: 19,
			style: 'position:absolute;left:102px;top:57px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись25',
			text: 'Период планирования:',
			style: 'position:absolute;left:342px;top:33px;width:120px;height:19px;text-align:left;',
		},
		{
			xtype: 'datefield',
			hideLabel: true,
			disabled: false,
			value: 0,
			format: 'd.m.Y',
			name: 'ПериодПланирования',
			width: 100,
			height: 19,
			style: 'position:absolute;left:464px;top:33px;width:100px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись26',
			text: 'Статья оборотов:',
			style: 'position:absolute;left:8px;top:81px;width:92px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-search-trigger',
			name: 'СтатьяОборотов',
			width: 220,
			height: 19,
			style: 'position:absolute;left:102px;top:81px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись27',
			text: 'Ед. измерения:',
			style: 'position:absolute;left:176px;top:105px;width:84px;height:19px;text-align:center;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			name: 'ЕдиницаИзмерения',
			width: 60,
			height: 19,
			style: 'position:absolute;left:262px;top:105px;width:60px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись32',
			text: 'Количество:',
			style: 'position:absolute;left:8px;top:105px;width:92px;height:19px;text-align:left;',
		},
		{
			xtype: 'numberfield',
			hideLabel: true,
			hideTrigger: true,
			disabled: false,
			value: 0,
			name: 'Количество',
			style: 'position:absolute;left:102px;top:105px;width:72px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись34',
			text: 'Валюта:',
			style: 'position:absolute;left:8px;top:129px;width:92px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			name: 'ВалютаДокумента',
			width: 80,
			height: 19,
			style: 'position:absolute;left:102px;top:129px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись35',
			text: 'Курс :',
			style: 'position:absolute;left:184px;top:129px;width:56px;height:19px;text-align:center;',
		},
		{
			xtype: 'numberfield',
			hideLabel: true,
			hideTrigger: true,
			disabled: true,
			value: 0,
			name: 'КурсДокумента',
			style: 'position:absolute;left:242px;top:129px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись38',
			text: 'Сумма:',
			style: 'position:absolute;left:342px;top:129px;width:88px;height:19px;text-align:left;',
		},
		{
			xtype: 'numberfield',
			hideLabel: true,
			hideTrigger: true,
			disabled: false,
			value: 0,
			name: 'Сумма',
			style: 'position:absolute;left:432px;top:129px;width:100px;height:19px;',
		},
		{
			xtype: 'numberfield',
			hideLabel: true,
			hideTrigger: true,
			disabled: false,
			value: 0,
			name: 'Цена',
			style: 'position:absolute;left:432px;top:105px;width:100px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьЦена',
			text: 'Цена:',
			style: 'position:absolute;left:342px;top:105px;width:88px;height:19px;text-align:left;',
		},
		{
			xtype: 'label',
			name: 'НадписьСуммаСценария',
			text: 'Сумма сценария = 100 USD',
			style: 'position:absolute;left:342px;top:57px;width:310px;height:19px;',
		},
		{
			xtype: 'tabpanel',
			style: 'position:absolute;left:8px;top:156px;width:644px;height:210px;',
			height: 210,width: 644,
			items:
			[
				{
					title:'Реквизиты операции',
					items:
					[
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			trigger3Cls: 'x-form-search-trigger',
			name: 'ЦФО',
			width: 220,
			height: 19,
			style: 'position:absolute;left:92px;top:6px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись29',
			text: 'Проект:',
			style: 'position:absolute;left:334px;top:6px;width:80px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			trigger3Cls: 'x-form-search-trigger',
			name: 'Проект',
			width: 220,
			height: 19,
			style: 'position:absolute;left:416px;top:6px;width:220px;height:19px;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			trigger3Cls: 'x-form-search-trigger',
			name: 'Контрагент',
			width: 220,
			height: 19,
			style: 'position:absolute;left:92px;top:31px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись31',
			text: 'Номенклатура:',
			style: 'position:absolute;left:334px;top:31px;width:80px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Номенклатура',
			width: 220,
			height: 19,
			style: 'position:absolute;left:416px;top:31px;width:220px;height:19px;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-search-trigger',
			name: 'Ответственный',
			width: 220,
			height: 19,
			style: 'position:absolute;left:92px;top:54px;width:220px;height:19px;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			name: 'Состояние',
			width: 220,
			height: 19,
			style: 'position:absolute;left:416px;top:54px;width:220px;height:19px;',
		},
					]
				},
				{
					title:'Зависимые обороты',
					items:
					[
		{
			xtype: 'label',
			name: 'Надпись28',
			text: 'ЦФО:',
			style: 'position:absolute;left:6px;top:6px;width:84px;height:19px;text-align:left;',
		},
		{
			id: 'ТабЗависимыеОбороты',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:24px;width:630px;height:160px;',
			height: 160,width: 630,
			columns:
			[
				{
					text:'Период',
					width:'108',
					dataIndex:'ПериодСтрока',
					flex:1,
				},
				{
					text:'Статья оборотов',
					width:'119',
					dataIndex:'СтатьяОборотов',
					flex:1,
				},
				{
					text:'ЦФО',
					width:'113',
					dataIndex:'ЦФО',
					flex:1,
				},
				{
					text:'Проект',
					width:'113',
					dataIndex:'Проект',
					flex:1,
				},
				{
					text:'Контрагент',
					width:'1200',
					dataIndex:'Контрагент',
					flex:1,
				},
				{
					text:'Номенклатура',
					width:'1200',
					dataIndex:'Номенклатура',
					flex:1,
				},
				{
					text:'Количество',
					width:'80',
					dataIndex:'Количество',
					flex:1,
				},
				{
					text:'Сумма',
					width:'80',
					dataIndex:'Сумма',
					flex:1,
				},
				{
					text:'Реквизит для расчета суммы',
					width:'1200',
					dataIndex:'РеквизитОперацииДляРасчетаСуммы',
					flex:1,
				},
				{
					text:'Коэффициент для расчета суммы',
					width:'1200',
					dataIndex:'КоэффициентДляРасчетаСуммы',
					flex:1,
				},
				{
					text:'Реквизит операции для расчета количества',
					width:'1200',
					dataIndex:'РеквизитОперацииДляРасчетаКоличества',
					flex:1,
				},
				{
					text:'Коэффициент для расчета количества',
					width:'1200',
					dataIndex:'КоэффициентДляРасчетаКоличества',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/БюджетнаяОперация/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'ПериодСтрока',
					},
					{
						name:'СтатьяОборотов',
					},
					{
						name:'ЦФО',
					},
					{
						name:'Проект',
					},
					{
						name:'Контрагент',
					},
					{
						name:'Номенклатура',
					},
					{
						name:'Количество',
					},
					{
						name:'Сумма',
					},
					{
						name:'РеквизитОперацииДляРасчетаСуммы',
					},
					{
						name:'КоэффициентДляРасчетаСуммы',
					},
					{
						name:'РеквизитОперацииДляРасчетаКоличества',
					},
					{
						name:'КоэффициентДляРасчетаКоличества',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('ТабЗависимыеОбороты');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data;
						Ext.require(['Справочники.Банки.ФормаЭлементаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.Банки.ФормаЭлементаСобытия");
							obj.ПередатьСсылку(ссылка);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:6px;top:0px;width:630px;height:24px;',
			items:
			[
				{
					text:'Заполнить',
				},
			]
		},
					]
				},
			]
		},
		{
			xtype: 'label',
			name: 'Надпись42',
			text: 'Комментарий:',
			style: 'position:absolute;left:8px;top:374px;width:92px;height:19px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Комментарий',
			width: 550,
			height: 19,
			style: 'position:absolute;left:102px;top:374px;width:550px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Период',
			text: '',
			style: 'position:absolute;left:482px;top:33px;width:115px;height:19px;text-align:center;',
		},
		{
			xtype: 'button',
			name: 'ПлюсПериод',
			text: '+',
			style: 'position:absolute;left:596px;top:33px;width:19px;height:19px;',
		},
		{
			xtype: 'button',
			name: 'МинусПериод',
			text: '-',
			style: 'position:absolute;left:464px;top:33px;width:19px;height:19px;',
		},
		{
			xtype: 'button',
			name: 'ВыборПериода',
			text: '',
			style: 'position:absolute;left:616px;top:33px;width:15px;height:19px;',
		},
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:659px;height:25px;',
			dock: 'top',
			items:
			[
				{
					xtype: 'splitbutton',
					text:'Действия',
					menu: [
				{
					text:'Файлы',
				},
					]
				},
				{
					xtype: 'splitbutton',
					text:'Перейти',
					menu: [
				{
					text:'Движения документа по регистрам',
				},
				{
					text:'Структура подчиненности документа',
				},
				'-',
					]
				},
				'-',
				{
					text:'',
				},
				{
					text:'',
				},
				'-',
				{
					text:'Файлы',
				},
			]
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:401px;width:659px;height:25px;',
			dock: 'bottom',
			items:
			[
				{
					xtype: 'tbfill'
				},
				{
					text:'Печать',
				},
				'-',
				{
					text:'OK',
				},
				'-',
				{
					text:'Записать',
				},
				'-',
				{
					text:'Закрыть',
				},
			]
		},
	]
});