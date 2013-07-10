﻿Ext.define('Справочники.НастройкаИнтервалов.ФормаЭлемента',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:384px;height:373px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Настройка интервала',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'label',
			name: 'НадписьНаименование',
			text: 'Наименование:',
			style: 'position:absolute;left:8px;top:33px;width:84px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Наименование',
			width: 283,
			height: 19,
			style: 'position:absolute;left:94px;top:33px;width:283px;height:19px;',
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:8px;top:76px;width:369px;height:24px;',
			items:
			[
			]
		},
		{
			id: 'ТабличнаяЧасть',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:100px;width:369px;height:240px;',
			height: 240,width: 369,
			columns:
			[
				{
					text:'№',
					width:'28',
					dataIndex:'НомерСтроки',
					flex:1,
				},
				{
					text:'Граница интервала',
					width:'1200',
					dataIndex:'НачалоИнтервала',
					flex:1,
				},
				{
					text:'Подпись в отчетах',
					width:'2200',
					dataIndex:'Подпись',
					flex:1,
				},
			],
			store:
			{
				data: Ext.create("Данные.Справочники.НастройкаИнтервалов").data,
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/НастройкаИнтервалов/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'НомерСтроки',
					},
					{
						name:'НачалоИнтервала',
					},
					{
						name:'Подпись',
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
						var грид = Ext.getCmp('ТабличнаяЧасть');
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
			style: 'position:absolute;left:0px;top:0px;width:384px;height:25px;',
			items:
			[
			]
		},
		{
			xtype: 'fieldset',
			title: 'Границы интервала',
			style: 'position:absolute;left:8px;top:60px;width:369px;height:16px;',
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:348px;width:384px;height:25px;',
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
		],
	}],
	dockedItems:
	[
	]
});