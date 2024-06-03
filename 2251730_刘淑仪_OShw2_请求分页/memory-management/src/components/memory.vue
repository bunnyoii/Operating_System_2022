<template>
  <div class="memory">

    <!--名称标题-->
    <el-row style="height: 35px">
      <el-col :span="5">
      <div>
        <a href="https://sse.tongji.edu.cn">
          <img style="height: 40px" src="https://z3.ax1x.com/2021/06/04/2Y8EWV.jpg">
        </a>
      </div>
      </el-col>
      <el-col :span="15">
        <h1 style="font-size: 24px;">操作系统 - 内存管理项目 - 请求调页存储管理方式模拟</h1>
      </el-col>
      <el-col :span="4">
        <div style="height: 100px">
          <p>
            2251730 刘淑仪
            <el-link type="info" underline="false" href="https://github.com/bunnyoii">GitHub主页</el-link>
          </p>

        </div>
      </el-col>
    </el-row>

    <!--分割线-->
    <div class="el-divider el-divider--horizontal" style="margin-bottom: 0"></div>

    <el-row :gutter="20" style="margin: 0; padding: 0">
      <!-- 综述 -->
      <el-col :span="5" style="width: 300px; height: 600px;">
        <p class="style_p">基本介绍</p>
        <div style="border: 2px solid #f3ccd1; padding: 1px; box-shadow: 5px 5px 10px rgb(255, 232, 236); border-radius: 15px;">
          <p>作业指令总数</p>
          <p class="style_p">320</p>
          <p>每页存放指令数</p>
          <p class="style_p">10</p>
          <p>作业占用内存页数</p>
          <p class="style_p">4</p>
          <p>页面置换算法</p>
          <el-radio-group text-color="#ffffff" fill="#FB8C9FFF" v-model="page_algorithm">
            <el-radio-button label="FIFO算法" class="fifo-button"></el-radio-button>
            <el-radio-button label="LRU算法" class="lru-button"></el-radio-button>
          </el-radio-group>
          <p>下一条指令地址</p>
          <p class="style_p">{{next_address == null ? 'None' : next_address}}</p>
          <p>缺页数</p>
          <p class="style_p">{{miss_page_num}}</p>
          <p>缺页率</p>
          <p class="style_p">{{miss_page_rate}}%</p>
          <p>执行速度(ms)</p>
          <p>
            <!-- 可以修改指令连续运行的速度 -->
            <el-input
                v-model="timePerExecution"
                style="width: 100px"
                placeholder="默认100"
            />
          </p>
        </div>
      </el-col>

      <!-- 内存中的界面图示 -->
      <el-col :span="13">
        <p class="style_p">内存中的页面图示</p>
        <div style="border: 2px solid #f3ccd1; padding: 30px; box-shadow: 5px 5px 10px rgb(255,232,236); border-radius: 15px;"> <!-- 添加圆角 -->
          <el-row :gutter="20">
            <el-col :span="6" v-for="(frameItem, index) in frame" :key="index">
              <el-container class="el-card is-always-shadow box-card" :style="frame_style[index]">
                <el-header class="el-card__header">
                  <p>第{{frameItem.num == null ? 'None' : frameItem.num}}页</p>
                </el-header>
                <div class="el-divider el-divider--horizontal" style="margin: 0"></div>
                <div class="el-card__body" style="height: 340px; padding: 10px">
                  <div class="transition-box" style="background: rgb(237,174,182);" :style="order_style[item]" v-for="item in frameItem.list" :key="item">{{item}}</div>
                </div>
              </el-container>
            </el-col>
          </el-row>
        </div>

        <!-- 执行按钮 -->
        <el-row :gutter="20" style="padding-top: 40px">
          <el-col :span="4"></el-col>
          <el-col :span="5">
            <el-button @click="single_step" v-bind:disabled="is_disabled" type="primary" icon="el-icon-arrow-right" round class="button-single-step">单步执行</el-button>
          </el-col>
          <el-col :span="5">
            <el-button @click="executable" type="primary" icon="el-icon-d-arrow-right" round class="button-continuous-exec">连续执行</el-button>
          </el-col>
          <el-col :span="5">
            <el-button @click="init" v-bind:disabled="is_disabled" class="el-button el-button--warning is-round button-reset" icon="el-icon-refresh-right" round>复位</el-button>
          </el-col>
          <el-col :span="9"></el-col>
        </el-row>

      </el-col>

      <!-- 已执行指令 -->
      <el-col :span="6">
        <p class="style_p">已执行指令</p>
        <div style="border: 2px solid #f3ccd1; padding: 15px; box-shadow: 5px 5px 10px rgb(255, 232, 236); border-radius: 15px;">
        <el-table
            :data="table_data"
            stripe
            highlight-current-row
            ref="table"
            height="540"
            style="width: 500px">
          <el-table-column
              prop="order"
              label="序号"
              width="60px">
          </el-table-column>
          <el-table-column
              prop="address"
              label="地址"
              width="70px">
          </el-table-column>
          <el-table-column
              prop="loss_page"
              label="是否缺页"
              width="70px">
          </el-table-column>
          <el-table-column
              prop="out_page"
              label="换出页"
              width="70px">
          </el-table-column>
          <el-table-column
              prop="in_page"
              label="换入页"
              width="70px">
          </el-table-column>
        </el-table>
        </div>
      </el-col>
    </el-row>


  </div>
</template>

<script>
export default {
  name: 'memory',
  props: {
    msg: String
  },
  data(){
    return{
      miss_page_num: 0,
      miss_page_rate: 0,
      page_algorithm: 'FIFO算法',
      frame: [{num: null, list: []}, {num: null, list: []}, {num: null, list: []}, {num: null, list: []},],
      table_data: [],
      is_disabled: false,
      page_data: [],
      next_address: null,
      pre_address: null,
      fifo_queue: [0, 1, 2, 3],
      lru_queue: [0, 0, 0, 0],
      interval: '',
      frame_style: ['','','',''],
      order_style: [],
      current_row: null,
      timePerExecution: 100,
    };
  },

  // 设定时间
  watch: {
    executeSpeed(timePerExecution) {
      if (isNaN(timePerExecution)) {
        this.timePerExecution = timePerExecution;
      }
    },
  },

  methods:{

    //单步执行
    single_step(){
      if(this.table_data.length === 320)
        return
      this.exec()
    },

    //连续执行
    executable : function (){
      if(this.table_data.length === 320){
        this.s_exec_name = '连续执行'
        this.is_disabled = false
        return
      }
      this.s_exec_name = this.s_exec_name === '连续执行' ? '停止执行' : '连续执行'
      this.is_disabled = !this.is_disabled
      if(this.is_disabled === true)
        this.interval = setInterval(this.exec, this.timePerExecution)
      else
        clearInterval(this.interval)
    },

    //复位
    init(){
      this.miss_page_num = 0
      this.miss_page_rate = 0
      this.frame = [{num: null, list: []}, {num: null, list: []}, {num: null, list: []}, {num: null, list: []},]
      this.table_data = []
      this.s_exec_name = '连续执行'
      this.is_disabled = false
      this.next_address = Math.floor(Math.random() * 320)
      this.pre_address = null
      this.fifo_queue = [0, 1, 2, 3]
      this.lru_queue = [0, 0, 0, 0]
      this.frame_style = ['','','','']
      this.current_row = null
      for(let i = 0; i < 320; i++)
        this.order_style.push('')
    },

    //返回应该放在哪个frame里以及换出页
    FIFO(){
      // 获取队列中最老的帧编号
      let oldestFrameNum = this.fifo_queue[0];
      // 移除队列首元素，并将其放回队尾
      this.fifo_queue.shift();
      this.fifo_queue.push(oldestFrameNum);

      // 同时更新LRU队列中对应帧的时间戳
      this.lru_queue[oldestFrameNum] = new Date().getTime();

      // 返回被替换帧的编号和其存储的页面编号
      return [oldestFrameNum, this.frame[oldestFrameNum].num];
    },
    LRU(){
      // 初始化为第一个帧编号
      let leastRecentlyUsedFrameNum = 0;

      // 找出最久未使用的帧
      for (let i = 1; i < this.lru_queue.length; i++) {
        if (this.lru_queue[i] < this.lru_queue[leastRecentlyUsedFrameNum]) {
          leastRecentlyUsedFrameNum = i;
        }
      }
      // 更新这个帧的时间戳为当前时间
      this.lru_queue[leastRecentlyUsedFrameNum] = new Date().getTime();

      // 同时更新FIFO队列，将这个帧从当前位置移除，并加到队尾
      this.fifo_queue.splice(this.fifo_queue.indexOf(leastRecentlyUsedFrameNum), 1);
      this.fifo_queue.push(leastRecentlyUsedFrameNum);

      // 返回被替换帧的编号和其存储的页面编号
      return [leastRecentlyUsedFrameNum, this.frame[leastRecentlyUsedFrameNum].num];
    },

    //执行一次
    exec() {
      if (this.table_data.length === 320) {
        // 当指令数量达到320时，停止执行并清理定时器
        this.s_exec_name = '连续执行';
        this.is_disabled = false;
        clearInterval(this.interval);
      } else {
        // 恢复上一条指令的样式
        this.frame_style = ['', '', '', ''];
        this.order_style[this.pre_address] = '';

        // 计算当前指令的页面编号
        let currentPage = Math.floor(this.next_address / 10);
        let pageFound = false; // 标记页面是否在内存中找到

        // 在内存帧中搜索当前页面
        for (let i = 0; i < this.frame.length; i++) {
          if (currentPage === this.frame[i].num) {
            this.lru_queue[i] = new Date().getTime(); // 更新页面的最近使用时间
            pageFound = true;
            break;
          }
        }

        // 高亮显示当前指令
        this.order_style[this.next_address] = { background: 'Orchid' };

        if (!pageFound) {
          // 页面未找到，处理页面置换
          this.miss_page_num++;
          this.miss_page_rate = Math.floor(this.miss_page_num * 100 / (this.table_data.length + 1));

          let replacementResult = this.page_algorithm === 'FIFO算法' ? this.FIFO() : this.LRU();
          this.frame_style[replacementResult[0]] = { background: '#FF8DACFF' };
          this.frame[replacementResult[0]].num = currentPage;
          this.frame[replacementResult[0]].list = this.page_data[currentPage];

          // 记录页面置换信息
          this.table_data.unshift({
            order: this.table_data.length,
            address: this.next_address,
            loss_page: 'Yes',
            out_page: replacementResult[1] ? replacementResult[1] : '',
            in_page: currentPage
          });
        } else {
          // 页面找到，记录访问信息
          this.table_data.unshift({
            order: this.table_data.length,
            address: this.next_address,
            loss_page: 'No',
            out_page: '',
            in_page: ''
          });
        }

        // 更新当前和下一条指令地址
        this.setCurrent();
        this.getNextAddress();
      }
    },

    //产生下一条指令地址
    getNextAddress() {
      this.pre_address = this.next_address
      let rand = Math.random()
      //顺序执行
      if (rand < 0.5)
        this.next_address = (this.next_address + 1) % 320
      let dx = Math.floor(Math.random() * 160)
      //25%的概率向后跳
      if (rand < 0.75 && rand >= 0.5)
        this.next_address = (this.next_address + dx) % 320
      //25%的概率向前跳
      if (rand >= 0.75)
        this.next_address = (this.next_address - dx + 320) % 320
    },
    //设置table当前行
    setCurrent() {
      this.$refs.table.setCurrentRow(this.table_data[0]);
    }
  },
  created() {
    //初始化页表
    for(let i = 0; i < 32; i++){
      let arr = []
      for(let j = i * 10; j < (i + 1) * 10; j++ )
        arr.push(j)
      this.page_data.push(arr)
    }
    //产生第一条指令
    this.next_address = Math.floor(Math.random() * 320)
    this.lru_queue = [0, 0, 0, 0]
    for(let i = 0; i < 320; i++)
      this.order_style.push('')
  }
}
</script>

<style>
.transition-box {
  width: 100px;
  height: 20px;
  text-align: center;
  color: #ad3e58;
  border: 1px solid;
  margin: 10px auto;
  border-radius: 4px;
}

.style_p {
  display: block;
  font-size: 1.17em;
  margin-block-start: 1em;
  margin-block-end: 1em;
  margin-inline-start: 0;
  margin-inline-end: 0;
  font-weight: bold;
}

/* 单步执行按钮 */
.button-single-step {
  background-color: #ffbcc4 !important; /* Cornflower Blue */
  border-color: #ffbcc4 !important;
}
.button-single-step:hover, .button-single-step:active {
  background-color: #edaeb6 !important; /* 深一点的Cornflower Blue */
  border-color: #edaeb6 !important;
}

/* 连续执行按钮 */
.button-continuous-exec {
  background-color: #edaede !important; /* Turquoise */
  border-color: #edaede !important;
}
.button-continuous-exec:hover, .button-continuous-exec:active {
  background-color: #c293b8 !important; /* 深一点的Turquoise */
  border-color: #c293b8 !important;
}

/* 复位按钮 */
.button-reset {
  background-color: #d8aeed !important; /* Gold */
  border-color: #d8aeed !important;
}
.button-reset:hover, .button-reset:active {
  background-color: #bb97cd !important; /* 深一点的Gold */
  border-color: #bb97cd !important;
}

.el-radio-group .el-radio-button .el-radio-button__inner:hover {
  color: #f3a4b3 !important; /* 悬浮时粉色字体 */
}

</style>