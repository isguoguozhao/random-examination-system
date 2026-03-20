# 完善缺失功能规格书

## Why
根据 spec.md 的要求和代码分析，发现以下功能尚未实现：
1. 必抽设置窗体（MustHitRuleForm）- 有服务层但无 UI
2. 操作日志查看窗体（LogForm）- 有服务层但无 UI
3. 数据备份恢复功能 - 需要验证实现状态

## What Changes
- 创建必抽设置窗体（MustHitRuleForm）
- 创建操作日志查看窗体（LogForm）
- 实现数据备份恢复功能
- 更新主窗体菜单事件，连接新窗体

## Impact
- 新增 UI 窗体文件
- 更新 MainForm.cs 中的菜单事件处理
- 完善系统管理功能模块

## ADDED Requirements

### Requirement: 必抽设置功能
系统 SHALL 提供必抽设置管理界面：
- 显示必抽规则列表
- 新增必抽规则（指挥组/任务）
- 编辑必抽规则
- 删除必抽规则
- 设置必抽级别（绝对必抽/优先必抽）
- 设置固定位置
- 设置生效时间范围

#### Scenario: 打开必抽设置
- **GIVEN** 用户点击系统管理菜单的"必抽设置"
- **WHEN** 用户有权限访问
- **THEN** 打开必抽设置窗体

#### Scenario: 新增必抽规则
- **GIVEN** 用户在必抽设置界面
- **WHEN** 点击新增按钮
- **THEN** 弹出编辑对话框
- **AND** 选择类型（指挥组/任务）
- **AND** 选择具体对象
- **AND** 设置必抽级别和位置
- **AND** 保存后添加到列表

### Requirement: 操作日志查看功能
系统 SHALL 提供操作日志查看界面：
- 显示日志列表（时间、用户、模块、操作类型、内容）
- 按时间范围筛选
- 按用户筛选
- 按模块筛选
- 分页显示
- 导出日志到 Excel
- 清空日志（管理员）

#### Scenario: 查看操作日志
- **GIVEN** 用户点击系统管理菜单的"操作日志"
- **WHEN** 用户有权限访问
- **THEN** 打开日志查看窗体
- **AND** 显示最近的操作日志

#### Scenario: 筛选日志
- **GIVEN** 用户在日志查看界面
- **WHEN** 选择筛选条件（时间/用户/模块）
- **THEN** 刷新列表显示符合条件的日志

### Requirement: 数据备份恢复功能
系统 SHALL 提供数据库备份和恢复功能：
- 备份数据库到指定路径
- 从备份文件恢复数据库
- 显示备份历史列表
- 自动备份设置（可选）

#### Scenario: 备份数据库
- **GIVEN** 管理员在系统管理中
- **WHEN** 点击数据备份
- **THEN** 选择备份路径
- **AND** 生成备份文件
- **AND** 记录备份信息

#### Scenario: 恢复数据库
- **GIVEN** 管理员在系统管理中
- **WHEN** 点击数据恢复
- **THEN** 选择备份文件
- **AND** 确认恢复（警告会覆盖现有数据）
- **AND** 执行恢复操作

## MODIFIED Requirements
### Requirement: 主窗体菜单事件
**修改内容**：将 MainForm.cs 中的 TODO 注释替换为实际窗体调用
- menuMustHitRule_Click：打开 MustHitRuleForm
- menuLog_Click：打开 LogForm

## REMOVED Requirements
无
