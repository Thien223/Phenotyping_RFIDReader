using Prism.Mvvm;
using System.Threading;
using System.Threading.Tasks;

namespace RFID.Cores
{
    public class SharedPreferences : BindableBase
    {

        private SharedPreferences()
        {
            Task.Factory.StartNew(() =>
            {
                while (MessageDisplayCountdown > 0)
                {
                    MessageDisplayCountdown -= 1000;
                    if (MessageDisplayCountdown <= 0)
                    {
                        StatusMessage = "";
                    }
                    Thread.Sleep(1000);
                }
            });
            
        }


        private static SharedPreferences m_Instance;
        public static SharedPreferences Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new SharedPreferences();
                }
                return m_Instance;
            }
        }


        #region Properties
        private MainWindowViewModel m_MainWindowViewModelInstance;
        public MainWindowViewModel MainWindowViewModelInstance
        {
            get
            {
                if(m_MainWindowViewModelInstance == null)
                {
                    m_MainWindowViewModelInstance = new MainWindowViewModel();
                }
                return m_MainWindowViewModelInstance;
            }
        }

        private int MessageDisplayCountdown = 10*1000;
        private string m_StatusMessage;
        public string StatusMessage
        {
            get { return m_StatusMessage; }
            set { m_StatusMessage = value;
                MessageDisplayCountdown = 10 * 1000;
                RaisePropertyChanged("StatusMessage");
            }
        }
        
        #endregion


        #region Boolean Properties
        #endregion



        #region Commands
        #endregion




        #region Methods
        #endregion

    }
}
