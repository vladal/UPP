﻿Ext.define('Документы.СправкаДругогоСтрахователяОЗаработке.ФормаДокумента',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:682px;height:327px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Справка другого страхователя о заработке',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'label',
			name: 'НадписьНомер',
			text: 'Номер:',
			style: 'position:absolute;left:361px;top:33px;width:92px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Номер',
			width: 80,
			height: 19,
			style: 'position:absolute;left:454px;top:33px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьОт',
			text: 'от:',
			style: 'position:absolute;left:534px;top:33px;width:20px;height:19px;text-align:center;',
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
			style: 'position:absolute;left:554px;top:33px;width:120px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьОрганизация',
			text: 'Организация:',
			style: 'position:absolute;left:8px;top:33px;width:100px;height:19px;text-align:left;',
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
			style: 'position:absolute;left:113px;top:33px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьОтветственный',
			text: 'Ответственный:',
			style: 'position:absolute;left:361px;top:58px;width:92px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			trigger3Cls: 'x-form-search-trigger',
			name: 'Ответственный',
			width: 220,
			height: 19,
			style: 'position:absolute;left:454px;top:58px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьРаботник',
			text: 'Сотрудник:',
			style: 'position:absolute;left:8px;top:58px;width:100px;height:19px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-search-trigger',
			name: 'Сотрудник',
			width: 220,
			height: 19,
			style: 'position:absolute;left:113px;top:58px;width:220px;height:19px;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-search-trigger',
			name: 'Страхователь',
			width: 220,
			height: 19,
			style: 'position:absolute;left:113px;top:83px;width:220px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьКомментарий',
			text: 'Комментарий:',
			style: 'position:absolute;left:8px;top:275px;width:86px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Комментарий',
			width: 578,
			height: 19,
			style: 'position:absolute;left:96px;top:275px;width:578px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьСтрахователь',
			text: 'Страхователь:',
			style: 'position:absolute;left:8px;top:83px;width:100px;height:19px;text-align:left;',
		},
		{
			id: 'ДанныеОЗаработке',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:136px;width:666px;height:132px;',
			height: 132,width: 666,
			columns:
			[
				{
					text:'№',
					width:'28',
					dataIndex:'НомерСтроки',
					flex:1,
				},
				{
					text:'Расчетный год',
					width:'100',
					dataIndex:'РасчетныйГод',
					flex:1,
				},
				{
					text:'Заработок',
					width:'100',
					dataIndex:'Заработок',
					flex:1,
				},
				{
					text:'Дней болезни, ухода за детьми и др.',
					width:'200',
					dataIndex:'ДнейБолезниУходаЗаДетьми',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/СправкаДругогоСтрахователяОЗаработке/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'НомерСтроки',
					},
					{
						name:'РасчетныйГод',
					},
					{
						name:'Заработок',
					},
					{
						name:'ДнейБолезниУходаЗаДетьми',
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
						var грид = Ext.getCmp('ДанныеОЗаработке');
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
			xtype: 'label',
			name: 'НадписьПериодРаботыС',
			text: 'Период работы с:',
			style: 'position:absolute;left:361px;top:83px;width:92px;height:19px;text-align:left;',
		},
		{
			xtype: 'datefield',
			hideLabel: true,
			disabled: false,
			value: 0,
			format: 'd.m.Y',
			name: 'ПериодРаботыС',
			width: 80,
			height: 19,
			style: 'position:absolute;left:454px;top:83px;width:80px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьПериодРаботыПо',
			text: 'по:',
			style: 'position:absolute;left:537px;top:83px;width:16px;height:19px;text-align:left;',
		},
		{
			xtype: 'datefield',
			hideLabel: true,
			disabled: false,
			value: 0,
			format: 'd.m.Y',
			name: 'ПериодРаботыПо',
			width: 80,
			height: 19,
			style: 'position:absolute;left:554px;top:83px;width:80px;height:19px;',
		},
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:682px;height:25px;',
			dock: 'top',
			items:
			[
			]
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:302px;width:682px;height:25px;',
			dock: 'bottom',
			items:
			[
				{
					xtype: 'tbfill'
				},
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
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:8px;top:112px;width:666px;height:24px;',
			dock: 'top',
			items:
			[
				{
					text:'&Добавить',
				},
				'-',
				{
					text:'',
				},
				{
					text:'Изменить',
				},
				{
					text:'Удалить',
				},
				'-',
				{
					text:'',
				},
				{
					text:'',
				},
				{
					text:'Конструктор настроек...',
				},
				{
					text:'',
				},
			]
		},
	]
});