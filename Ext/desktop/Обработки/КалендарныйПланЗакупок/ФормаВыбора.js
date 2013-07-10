﻿Ext.define('Обработки.КалендарныйПланЗакупок.ФормаВыбора',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:376px;height:322px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Группировки отчета',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'Дерево',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:8px;width:360px;height:280px;',
			height: 280,width: 360,
			columns:
			[
				{
					text:'ПредставлениеФильтра',
					width:'209',
					dataIndex:'ПредставлениеФильтра',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/КалендарныйПланЗакупок/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'ПредставлениеФильтра',
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
						var грид = Ext.getCmp('Дерево');
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
			style: 'position:absolute;left:0px;top:297px;width:376px;height:25px;',
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
					text:'Закрыть',
				},
				'-',
				{
					text:'Справка',
				},
			]
		},
		],
	}],
	dockedItems:
	[
	]
});