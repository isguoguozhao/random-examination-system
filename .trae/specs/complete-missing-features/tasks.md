# 完善缺失功能任务列表

## Task 1: 创建必抽设置窗体 (MustHitRuleForm)

- [x] SubTask 1.1: 创建 MustHitRuleForm 窗体文件
  - 设计窗体 UI（列表、按钮、筛选区）
  - 设置窗体属性（标题、大小、图标）

- [x] SubTask 1.2: 实现必抽规则列表显示
  - 使用 DataGridView 显示规则列表
  - 显示字段：类型、对象名称、必抽级别、固定位置、生效时间

- [x] SubTask 1.3: 实现新增/编辑规则功能
  - 创建 MustHitRuleEditForm 编辑对话框
  - 选择类型（指挥组/任务）
  - 选择具体对象（下拉框）
  - 设置必抽级别（单选框）
  - 设置固定位置（数字输入）
  - 设置生效时间范围（日期选择器）

- [x] SubTask 1.4: 实现删除规则功能
  - 选中行后点击删除
  - 确认对话框
  - 调用 MustHitRuleService.Delete

- [x] SubTask 1.5: 实现规则查询功能
  - 按活动筛选（如果适用）
  - 按类型筛选

## Task 2: 创建操作日志查看窗体 (LogForm)

- [x] SubTask 2.1: 创建 LogForm 窗体文件
  - 设计窗体 UI（列表、筛选区、按钮）
  - 设置窗体属性

- [x] SubTask 2.2: 实现日志列表显示
  - 使用 DataGridView 显示日志
  - 显示字段：时间、用户名、模块、操作类型、操作内容
  - 分页显示（每页50条）

- [x] SubTask 2.3: 实现日志筛选功能
  - 时间范围筛选（开始时间-结束时间）
  - 用户筛选（下拉框选择）
  - 模块筛选（下拉框选择）
  - 操作类型筛选

- [x] SubTask 2.4: 实现日志导出功能
  - 导出当前筛选结果到 Excel
  - 使用 EPPlus 库

- [x] SubTask 2.5: 实现清空日志功能（管理员）
  - 确认对话框（警告）
  - 清空所有日志或按条件清空

## Task 3: 实现数据备份恢复功能

- [ ] SubTask 3.1: 创建 DatabaseBackupService 服务类
  - 实现 Backup 方法（备份数据库文件）
  - 实现 Restore 方法（恢复数据库文件）
  - 实现 GetBackupHistory 方法（获取备份历史）

- [ ] SubTask 3.2: 创建数据备份恢复窗体 (DatabaseBackupForm)
  - 设计窗体 UI
  - 显示备份历史列表
  - 备份按钮（选择路径）
  - 恢复按钮（选择文件）

- [ ] SubTask 3.3: 在主窗体添加数据备份菜单
  - 在系统管理菜单下添加"数据备份"菜单项
  - 实现菜单点击事件

## Task 4: 更新主窗体菜单事件

- [x] SubTask 4.1: 更新 menuMustHitRule_Click 方法
  - 移除 TODO 注释
  - 实例化并显示 MustHitRuleForm

- [x] SubTask 4.2: 更新 menuLog_Click 方法
  - 移除 TODO 注释
  - 实例化并显示 LogForm

## Task 5: 更新项目文件

- [x] SubTask 5.1: 更新 .csproj 文件
  - 添加新创建的窗体文件到项目

- [ ] SubTask 5.2: 编译测试
  - 确保所有新文件编译通过
  - 测试功能完整性

# 任务依赖关系

- Task 1 和 Task 2 可以并行进行
- Task 3 依赖于 Task 1 和 Task 2 完成（可选，可以独立进行）
- Task 4 依赖于 Task 1 和 Task 2 完成
- Task 5 依赖于所有其他任务完成
