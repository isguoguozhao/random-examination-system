# UI优化任务列表

## Task 1: 集成SunnyUI库

- [ ] SubTask 1.1: 安装SunnyUI NuGet包
  - 在NuGet包管理器中搜索SunnyUI
  - 安装最新稳定版本
  - 确认引用添加成功

- [ ] SubTask 1.2: 创建SunnyUI主题配置
  - 创建主题配置文件
  - 设置主色调：深蓝(#003366)
  - 设置辅助色：米黄(#F5F5DC)
  - 设置按钮样式、字体等

- [ ] SubTask 1.3: 更新项目引用
  - 确保所有窗体可以访问SunnyUI控件
  - 添加using引用

## Task 2: 按钮尺寸优化

- [ ] SubTask 2.1: 更新LoginForm按钮
  - 登录按钮高度调整为40px
  - 字体大小调整为12pt
  - 应用SunnyUI按钮样式

- [ ] SubTask 2.2: 更新MainForm工具栏按钮
  - 所有工具栏按钮高度40px
  - 增大按钮间距

- [ ] SubTask 2.3: 更新所有数据管理窗体按钮
  - OrgUnitForm按钮优化
  - PersonForm按钮优化
  - CommandGroupForm按钮优化
  - TaskPlanForm按钮优化
  - UserManageForm按钮优化

- [ ] SubTask 2.4: 更新编辑对话框按钮
  - 所有EditForm按钮统一尺寸

## Task 3: 信息栏中文化

- [ ] SubTask 3.1: 更新MainForm状态栏
  - 将英文状态信息改为中文
  - 更新状态栏显示格式

- [ ] SubTask 3.2: 更新所有提示信息
  - 检查所有MessageBox提示
  - 将英文提示改为中文

- [ ] SubTask 3.3: 更新错误信息
  - 统一错误提示为中文
  - 优化错误信息描述

## Task 4: 简化任务方案编辑界面

- [ ] SubTask 4.1: 修改TaskPlanDetail实体
  - 移除TaskDescription字段
  - 更新数据库表结构

- [ ] SubTask 4.2: 更新TaskPlanEditForm界面
  - 只保留任务名称和分配单位
  - 移除其他字段的输入控件
  - 调整界面布局

- [ ] SubTask 4.3: 更新TaskPlanService
  - 调整数据访问逻辑
  - 移除TaskDescription相关代码

## Task 5: 重新设计抽考流程

- [ ] SubTask 5.1: 创建新的抽考流程窗体
  - 创建NewExamDrawForm
  - 设计四步抽取界面

- [ ] SubTask 5.2: 实现Step 1 - 抽取考核内容1任务
  - 创建滚动动画效果
  - 实现开始/停止抽取逻辑
  - 显示抽取结果

- [ ] SubTask 5.3: 实现Step 2 - 抽取考核内容2任务
  - 复用滚动动画组件
  - 实现任务抽取逻辑

- [ ] SubTask 5.4: 实现Step 3 - 抽取考核内容1指挥员
  - 从指挥组中抽取值班指挥员
  - 实现滚动动画

- [ ] SubTask 5.5: 实现Step 4 - 抽取考核内容2指挥员
  - 实现指挥员抽取逻辑
  - 完成四步抽取流程

- [ ] SubTask 5.6: 实现最终结果显示
  - 创建结果表格
  - 表格列：序号、考核内容、姓名、部职别
  - 实现导出和打印功能

## Task 6: 优化整体UI风格

- [ ] SubTask 6.1: 更新所有窗体背景色
  - 主背景色：米黄(#F5F5DC)
  - 标题栏：深蓝(#003366)

- [ ] SubTask 6.2: 更新所有按钮样式
  - 使用SunnyUI按钮
  - 应用配色方案

- [ ] SubTask 6.3: 更新所有表格样式
  - 使用SunnyUI表格控件
  - 统一表格配色

- [ ] SubTask 6.4: 更新所有输入控件
  - 文本框、下拉框等使用SunnyUI样式

## Task 7: 数据结构调整

- [ ] SubTask 7.1: 更新ExamActivity实体
  - 添加考核内容1和2的存储字段
  - 添加指挥员抽取结果字段

- [ ] SubTask 7.2: 更新数据库初始化脚本
  - 调整表结构
  - 添加新字段

- [ ] SubTask 7.3: 更新ExamService
  - 适配新的数据结构
  - 实现新的抽取逻辑

## Task 8: 测试和验证

- [ ] SubTask 8.1: 编译测试
  - 确保所有窗体编译通过
  - 检查SunnyUI引用

- [ ] SubTask 8.2: 功能测试
  - 测试所有按钮功能
  - 测试抽考流程
  - 测试数据导入导出

- [ ] SubTask 8.3: UI测试
  - 验证配色方案
  - 验证按钮尺寸
  - 验证中文化

# 任务依赖关系

- Task 1 必须在其他任务之前完成
- Task 2、3、4 可以并行进行
- Task 5 依赖于 Task 1 和 Task 4
- Task 6 依赖于 Task 1 和 Task 2
- Task 7 依赖于 Task 4
- Task 8 必须在所有其他任务完成后进行
