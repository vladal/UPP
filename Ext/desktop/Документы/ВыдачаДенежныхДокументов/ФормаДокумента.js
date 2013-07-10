﻿Ext.define('Документы.ВыдачаДенежныхДокументов.ФормаДокумента',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:670px;height:371px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Выдача денежных документов',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'label',
			name: 'НадписьНомер',
			text: 'Номер:',
			style: 'position:absolute;left:8px;top:33px;width:88px;height:19px;text-align:left;',
		},
		{
			xtype: 'label',
			name: 'НадписьДата',
			text: 'от:',
			style: 'position:absolute;left:186px;top:33px;width:16px;height:19px;text-align:center;',
		},
		{
			xtype: 'label',
			name: 'НадписьКомментарий',
			text: 'Комментарий:',
			style: 'position:absolute;left:8px;top:319px;width:92px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Номер',
			width: 88,
			height: 19,
			style: 'position:absolute;left:96px;top:33px;width:88px;height:19px;',
		},
		{
			xtype: 'datefield',
			hideLabel: true,
			disabled: false,
			value: 0,
			format: 'd.m.Y',
			name: 'Дата',
			width: 112,
			height: 19,
			style: 'position:absolute;left:204px;top:33px;width:112px;height:19px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Комментарий',
			width: 560,
			height: 19,
			style: 'position:absolute;left:102px;top:319px;width:560px;height:19px;',
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:670px;height:25px;',
			items:
			[
			]
		},
		{
			xtype: 'tabpanel',
			style: 'position:absolute;left:8px;top:107px;width:654px;height:159px;',
			height: 159,width: 654,
			items:
			[
				{
					title:'Кому',
					items:
					[
		{
			xtype: 'tabpanel',
			style: 'position:absolute;left:6px;top:6px;width:640px;height:126px;',
			height: 126,width: 640,
			tabBar:{hidden:true},
			items:
			[
				{
					title:'Возврат поставщику',
					items:
					[
		{
			xtype: 'label',
			name: 'НадписьСчетУчетаРасчетовСКонтрагентом',
			text: 'Счет расчетов:',
			style: 'position:absolute;left:0px;top:80px;width:82px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			name: 'СчетУчетаРасчетовСКонтрагентом',
			width: 80,
			height: 19,
			style: 'position:absolute;left:82px;top:80px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьКонтрагент',
			text: 'Контрагент:',
			style: 'position:absolute;left:0px;top:0px;width:82px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-search-trigger',
			name: 'ДоговорКонтрагента',
			width: 220,
			height: 19,
			style: 'position:absolute;left:82px;top:54px;width:220px;height:19px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Контрагент',
			width: 220,
			height: 19,
			style: 'position:absolute;left:82px;top:0px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьДоговор',
			text: 'Договор:',
			style: 'position:absolute;left:0px;top:54px;width:82px;height:19px;text-align:left;',
		},
		{
			xtype: 'label',
			name: 'НадписьВыдано',
			text: 'Выдано:',
			style: 'position:absolute;left:0px;top:26px;width:82px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Выдано',
			width: 558,
			height: 19,
			style: 'position:absolute;left:82px;top:26px;width:558px;height:19px;',
		},
					]
				},
				{
					title:'Прочее',
					items:
					[
		{
			xtype: 'label',
			name: 'НадписьСчетУчетаРасчетовСКонтрагентомПрочее',
			text: 'Счет дебета:',
			style: 'position:absolute;left:0px;top:28px;width:82px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			name: 'СчетУчетаРасчетовСКонтрагентомПрочее',
			width: 80,
			height: 19,
			style: 'position:absolute;left:83px;top:28px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьСубконтоДт1',
			text: 'Субконто Дт1:',
			style: 'position:absolute;left:0px;top:53px;width:82px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			name: 'СубконтоДт1',
			width: 220,
			height: 19,
			style: 'position:absolute;left:83px;top:53px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьСубконтоДт2',
			text: 'Субконто Дт2:',
			style: 'position:absolute;left:0px;top:78px;width:82px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			name: 'СубконтоДт2',
			width: 220,
			height: 19,
			style: 'position:absolute;left:83px;top:78px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьСубконтоДт3',
			text: 'Субконто Дт3:',
			style: 'position:absolute;left:0px;top:103px;width:82px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			name: 'СубконтоДт3',
			width: 220,
			height: 19,
			style: 'position:absolute;left:83px;top:103px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьВыданоПрочее',
			text: 'Выдано:',
			style: 'position:absolute;left:0px;top:0px;width:82px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'ВыданоПрочее',
			width: 558,
			height: 19,
			style: 'position:absolute;left:82px;top:0px;width:558px;height:19px;',
		},
					]
				},
				{
					title:'Выдача подотчетному лицу',
					items:
					[
		{
			xtype: 'label',
			name: 'НадписьПодотчетноеЛицо',
			text: 'Подотчетное лицо:',
			style: 'position:absolute;left:0px;top:0px;width:80px;height:29px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'ПодотчетноеЛицо',
			width: 220,
			height: 19,
			style: 'position:absolute;left:83px;top:0px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьВыданоПодотчетноеЛицо',
			text: 'Выдано:',
			style: 'position:absolute;left:0px;top:29px;width:80px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'ВыданоПодотчетноеЛицо',
			width: 557,
			height: 19,
			style: 'position:absolute;left:83px;top:29px;width:557px;height:19px;',
		},
					]
				},
			]
		},
					]
				},
				{
					title:'Денежные документы',
					items:
					[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:6px;top:6px;width:640px;height:24px;',
			items:
			[
				'-',
			]
		},
		{
			id: 'ДенежныеДокументы',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:30px;width:640px;height:102px;',
			height: 102,width: 640,
			columns:
			[
				{
					text:'№',
					width:'28',
					dataIndex:'НомерСтроки',
					flex:1,
				},
				{
					text:'Денежный документ',
					width:'1800',
					dataIndex:'ДенежныйДокумент',
					flex:1,
				},
				{
					text:'Количество',
					width:'100',
					dataIndex:'Количество',
					flex:1,
				},
				{
					text:'Стоимость',
					width:'1200',
					dataIndex:'Стоимость',
					flex:1,
				},
				{
					text:'Сумма возврата',
					width:'1200',
					dataIndex:'Сумма',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ВыдачаДенежныхДокументов/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'НомерСтроки',
					},
					{
						name:'ДенежныйДокумент',
					},
					{
						name:'Количество',
					},
					{
						name:'Стоимость',
					},
					{
						name:'Сумма',
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
						var грид = Ext.getCmp('ДенежныеДокументы');
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
					]
				},
				{
					title:'Счета доходов и расходов',
					items:
					[
		{
			xtype: 'fieldset',
			title: 'Счета учета разниц между учетной стоимостью денежных документов и суммой возврата',
			style: 'position:absolute;left:6px;top:13px;width:640px;height:16px;',
		},
		{
			xtype: 'label',
			name: 'НадписьСчетУчетаДоходов',
			text: 'Счет учета доходов:',
			style: 'position:absolute;left:6px;top:57px;width:150px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			name: 'СчетУчетаДоходов',
			width: 80,
			height: 19,
			style: 'position:absolute;left:160px;top:57px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьСчетУчетаРасходов',
			text: 'Счет учета расходов:',
			style: 'position:absolute;left:6px;top:80px;width:150px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			name: 'СчетУчетаРасходов',
			width: 80,
			height: 19,
			style: 'position:absolute;left:160px;top:80px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьСтатьяДоходовИРасходов',
			text: 'Статья доходов и расходов:',
			style: 'position:absolute;left:6px;top:34px;width:150px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			name: 'СтатьяДоходовИРасходов',
			width: 357,
			height: 19,
			style: 'position:absolute;left:160px;top:34px;width:357px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьСчетУчетаДоходовНУ',
			text: 'Счет учета доходов (НУ):',
			style: 'position:absolute;left:283px;top:57px;width:150px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			name: 'СчетУчетаДоходовНУ',
			width: 80,
			height: 19,
			style: 'position:absolute;left:437px;top:57px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьСчетУчетаРасходовНУ',
			text: 'Счет учета расходов (НУ):',
			style: 'position:absolute;left:283px;top:80px;width:150px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			name: 'СчетУчетаРасходовНУ',
			width: 80,
			height: 19,
			style: 'position:absolute;left:437px;top:80px;width:80px;height:19px;',
		},
					]
				},
			]
		},
		{
			xtype: 'label',
			name: 'НадписьОтветственный',
			text: 'Ответственный:',
			style: 'position:absolute;left:8px;top:295px;width:92px;height:19px;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			trigger3Cls: 'x-form-search-trigger',
			name: 'Ответственный',
			width: 560,
			height: 19,
			style: 'position:absolute;left:102px;top:295px;width:560px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьВсего',
			text: 'Всего,USD:',
			style: 'position:absolute;left:470px;top:271px;width:72px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Всего',
			width: 120,
			height: 19,
			style: 'position:absolute;left:542px;top:271px;width:120px;height:19px;',
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:346px;width:670px;height:25px;',
			items:
			[
				{
					xtype: 'tbfill'
				},
				{
					text:'ОК',
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
		{
			xtype: 'label',
			name: 'НадписьОрганизация',
			text: 'Организация:',
			style: 'position:absolute;left:8px;top:57px;width:88px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-search-trigger',
			name: 'Организация',
			width: 220,
			height: 19,
			style: 'position:absolute;left:96px;top:57px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьСчетУчетаДенежныхДокументов',
			text: 'Счет учета:',
			style: 'position:absolute;left:8px;top:81px;width:88px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			name: 'СчетУчетаДенежныхДокументов',
			width: 80,
			height: 19,
			style: 'position:absolute;left:96px;top:81px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьВалютаДокумента',
			text: 'Валюта:',
			style: 'position:absolute;left:191px;top:81px;width:44px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			name: 'ВалютаДокумента',
			width: 80,
			height: 19,
			style: 'position:absolute;left:236px;top:81px;width:80px;height:19px;',
		},
		],
	}],
	dockedItems:
	[
	]
});